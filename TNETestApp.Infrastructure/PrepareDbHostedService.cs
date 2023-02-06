using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TNETestApp.Domain.Enums;
using TNETestApp.Domain.Models;

namespace TNETestApp.Infrastructure
{
    public class PrepareDbHostedService : BackgroundService
    {
        private readonly DataContext _conext;
        private readonly ILogger<PrepareDbHostedService> _logger;
        public PrepareDbHostedService(DataContext conext, ILogger<PrepareDbHostedService> logger)
        {
            _conext = conext;
            _logger = logger;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                await _conext.Database.MigrateAsync(stoppingToken);
                await AddData(stoppingToken);
                await StopAsync(stoppingToken);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "PrepareDb failed");
            }
        }

        public override async Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("PrepareDb Hosted Service is stopping");
            await base.StopAsync(cancellationToken);
        }

        private async Task AddData(CancellationToken cancellationToken)
        {
            await AddCompanies(cancellationToken);
            await AddSubsidiaryCompanies(cancellationToken);
            await AddConsumerBuilding(cancellationToken);
            await AddDeliveryPoints(cancellationToken);
            await AddMeasuringPoints(cancellationToken);
            await AddElectircityMeter(cancellationToken);
            await AddCurrentTransformers(cancellationToken);
            await AddVoltageTransformers(cancellationToken);
            await AddMeteringDevices(cancellationToken);

        }

        private async Task AddCompanies(CancellationToken cancellationToken)
        {
            var companies =  new List<Company>
            {
                new Company() { Name = "ООО Рога и копыта", Address = "Г. Москва, ул. Липовая 8" },
                new Company() { Name = "ПАО ТКЛ", Address = "Г. Курган, ул. Ленина 5" },
                new Company() { Name = "АО Холдинг", Address = "Г. Тверь, ул. Гоголя 36" },
                new Company() { Name = "ПАО Стройка", Address = "Г. Екатеринбург, ул. Дзержинского 54а" },
                new Company() { Name = "ПАО Серб", Address = "Г. Челябинск, ул. Ленина 21" }
            };

            _conext.Companies.AddRange(companies);
            await _conext.SaveChangesAsync(cancellationToken);
        }

        private async Task AddSubsidiaryCompanies(CancellationToken cancellationToken)
        {
            var subsidiaryCompanies = new List<SubsidiaryCompany>
            {
                new SubsidiaryCompany() { Name = "Рога и копыто", Address = "г. Зеленоград", CompanyId = 1 },
                new SubsidiaryCompany() { Name = "Рога и копыто", Address = "г. Петропавловск", CompanyId = 1 },
                new SubsidiaryCompany() { Name = "Рога и копыто", Address = "г. Балашиха", CompanyId = 1 },
                new SubsidiaryCompany() { Name = "Холодинг", Address = "г. Тверь", CompanyId = 3 },
                new SubsidiaryCompany() { Name = "Серб", Address = "г. Курган", CompanyId = 5 }
            };

            _conext.SubsidiaryCompanies.AddRange(subsidiaryCompanies);
            await _conext.SaveChangesAsync(cancellationToken);
        }

        private async Task AddConsumerBuilding(CancellationToken cancellationToken)
        {
            var consumerBuildings = new List<ConsumerBuilding>
            {
                new ConsumerBuilding() { Name = "ПС 110/10 Весна", Address = "Тверь", CompanyId = 3, SubsidiaryCompanyId = 4 },
                new ConsumerBuilding() { Name = "ПС 150/12 Золотой единорог", Address = "Челябинск", CompanyId = 5 },
                new ConsumerBuilding() { Name = "ПС 250/21 Гидеон", Address = "Москва", CompanyId = 1 },
                new ConsumerBuilding() { Name = "ПС 3802/54 Олимп", Address = "Зеленоград", CompanyId = 1, SubsidiaryCompanyId = 1 },
                new ConsumerBuilding() { Name = "ПС 12/8 Осень", Address = "Курган", CompanyId = 5, SubsidiaryCompanyId = 5 },
                new ConsumerBuilding() { Name = "ПС 145/11 Зима", Address = "Курган", CompanyId = 2 },
                new ConsumerBuilding() { Name = "ПС 123/13 Лето", Address = "Екатеринбург", CompanyId = 4 },
                new ConsumerBuilding() { Name = "ПС 144/123 Юпитер", Address = "Петропавловск", CompanyId = 1, SubsidiaryCompanyId = 2 },
                new ConsumerBuilding() { Name = "ПС 154/113 Венера", Address = "Балашиха", CompanyId = 1, SubsidiaryCompanyId = 3 }
            };

            _conext.ConsumerBuildings.AddRange(consumerBuildings);
            await _conext.SaveChangesAsync(cancellationToken);
        }

        private async Task AddDeliveryPoints(CancellationToken cancellationToken)
        {
            var deliveryPoints = new List<DeliveryPoint>
            {
                new DeliveryPoint() { Name = "ТПЭ Весна", MaxPower = 50, ConsumerBuildingId = 1 },
                new DeliveryPoint() { Name = "ТПЭ Золотой единорог", MaxPower = 37, ConsumerBuildingId = 2 },
                new DeliveryPoint() { Name = "ТПЭ Гидеон", MaxPower = 149, ConsumerBuildingId = 3 },
                new DeliveryPoint() { Name = "ТПЭ Олимп", MaxPower = 90, ConsumerBuildingId = 4 },
                new DeliveryPoint() { Name = "ТПЭ Осень", MaxPower = 45, ConsumerBuildingId = 5 },
                new DeliveryPoint() { Name = "ТПЭ Зима", MaxPower = 45, ConsumerBuildingId = 6 },
                new DeliveryPoint() { Name = "ТПЭ Лето", MaxPower = 170, ConsumerBuildingId = 7 },
                new DeliveryPoint() { Name = "ТПЭ Юпитер", MaxPower = 70, ConsumerBuildingId = 8 },
                new DeliveryPoint() { Name = "ТПЭ Венера", MaxPower = 66, ConsumerBuildingId = 9 }
            };

            _conext.DeliveryPoints.AddRange(deliveryPoints);
            await _conext.SaveChangesAsync(cancellationToken);
        }

        private async Task AddMeasuringPoints(CancellationToken cancellationToken)
        {
            var measuringPoints = new List<MeasuringPoint>
            {
                new MeasuringPoint() { Name = "ГРЩ", ConsumerBuildingId = 1},
                new MeasuringPoint() { Name = "ВРЩ", ConsumerBuildingId = 1},
                new MeasuringPoint() { Name = "ГРЩ", ConsumerBuildingId = 2},
                new MeasuringPoint() { Name = "ГРЩ", ConsumerBuildingId = 3},
                new MeasuringPoint() { Name = "ГРЩ", ConsumerBuildingId = 4},
                new MeasuringPoint() { Name = "ВРЩ-1", ConsumerBuildingId = 4},
                new MeasuringPoint() { Name = "ВРЩ-2", ConsumerBuildingId = 4},
                new MeasuringPoint() { Name = "ГРЩ", ConsumerBuildingId = 5},
                new MeasuringPoint() { Name = "ГРЩ", ConsumerBuildingId = 6},
                new MeasuringPoint() { Name = "ГРЩ", ConsumerBuildingId = 7},
                new MeasuringPoint() { Name = "ГРЩ", ConsumerBuildingId = 8},
                new MeasuringPoint() { Name = "ГРЩ", ConsumerBuildingId = 9},
                new MeasuringPoint() { Name = "ВРЩ-1", ConsumerBuildingId = 9},
                new MeasuringPoint() { Name = "ВРЩ-2", ConsumerBuildingId = 9},
                new MeasuringPoint() { Name = "ВРЩ-3", ConsumerBuildingId = 9},
            };

            _conext.MeasuringPoints.AddRange(measuringPoints);
            await _conext.SaveChangesAsync(cancellationToken);
        }

        private async Task AddElectircityMeter(CancellationToken cancellationToken)
        {
            var electricityMeters = new List<ElectricityMeter>
            {
                new ElectricityMeter() { Number = 345, MeterType = ElectricityMeterType.TypeY, VerificationDate = new DateTime(2020, 2, 3), OutOfVerificationDate = new DateTime(2024, 2, 3), MeasuringPointId = 1 },
                new ElectricityMeter() { Number = 321, MeterType = ElectricityMeterType.TypeY, VerificationDate = new DateTime(2018, 4, 6), OutOfVerificationDate = new DateTime(2024, 2, 3), MeasuringPointId = 2 },
                new ElectricityMeter() { Number = 666, MeterType = ElectricityMeterType.TypeX, VerificationDate = new DateTime(2016, 6, 12), OutOfVerificationDate = new DateTime(2019, 4, 20), MeasuringPointId = 3 },
                new ElectricityMeter() { Number = 654, MeterType = ElectricityMeterType.TypeZ, VerificationDate = new DateTime(2017, 1, 19), OutOfVerificationDate = new DateTime(2023, 9, 16), MeasuringPointId = 4 },
                new ElectricityMeter() { Number = 459, MeterType = ElectricityMeterType.TypeZ, VerificationDate = new DateTime(2021, 9, 3), OutOfVerificationDate = new DateTime(2024, 11, 20), MeasuringPointId = 5 },
                new ElectricityMeter() { Number = 126, MeterType = ElectricityMeterType.TypeX, VerificationDate = new DateTime(2019, 1, 2), OutOfVerificationDate = new DateTime(2021, 4, 20), MeasuringPointId = 6 },
                new ElectricityMeter() { Number = 453, MeterType = ElectricityMeterType.TypeY, VerificationDate = new DateTime(2017, 5, 14), OutOfVerificationDate = new DateTime(2020, 8, 24), MeasuringPointId = 7 },
                new ElectricityMeter() { Number = 265, MeterType = ElectricityMeterType.TypeX, VerificationDate = new DateTime(2018, 4, 2), OutOfVerificationDate = new DateTime(2024, 4, 20), MeasuringPointId = 8 },
                new ElectricityMeter() { Number = 786, MeterType = ElectricityMeterType.TypeZ, VerificationDate = new DateTime(2022, 1, 22), OutOfVerificationDate = new DateTime(2022, 6, 10), MeasuringPointId = 9 },
                new ElectricityMeter() { Number = 159, MeterType = ElectricityMeterType.TypeX, VerificationDate = new DateTime(2023, 1, 2), OutOfVerificationDate = new DateTime(2024, 12, 29), MeasuringPointId = 10 },
                new ElectricityMeter() { Number = 753, MeterType = ElectricityMeterType.TypeZ, VerificationDate = new DateTime(2021, 4, 22), OutOfVerificationDate = new DateTime(2025, 4, 24), MeasuringPointId = 11 },
                new ElectricityMeter() { Number = 357, MeterType = ElectricityMeterType.TypeY, VerificationDate = new DateTime(2020, 7, 12), OutOfVerificationDate = new DateTime(2024, 10, 20), MeasuringPointId = 12 },
                new ElectricityMeter() { Number = 267, MeterType = ElectricityMeterType.TypeZ, VerificationDate = new DateTime(2018, 5, 4), OutOfVerificationDate = new DateTime(2024, 7, 20), MeasuringPointId = 13 },
                new ElectricityMeter() { Number = 129, MeterType = ElectricityMeterType.TypeX, VerificationDate = new DateTime(2020, 7, 20), OutOfVerificationDate = new DateTime(2022, 12, 6), MeasuringPointId = 14 },
                new ElectricityMeter() { Number = 691, MeterType = ElectricityMeterType.TypeY, VerificationDate = new DateTime(2019, 3, 17), OutOfVerificationDate = new DateTime(2022, 4, 5), MeasuringPointId = 15 }
            };

            _conext.ElectricityMeters.AddRange(electricityMeters);
            await _conext.SaveChangesAsync(cancellationToken);
        }

        private async Task AddCurrentTransformers(CancellationToken cancellationToken)
        {
            var currentTransformers = new List<CurrentTransformer>
            {
                new CurrentTransformer() { Number = 112, TransformatorType = CurrentTransformatorType.TypeA, TransformerRatio = Ratio.CurrentTransformerRatioA, VerificationDate = new DateTime(2020, 11, 4), OutOfVerificationDate = new DateTime(2022, 12, 6), MeasuringPointId = 1 },
                new CurrentTransformer() { Number = 159, TransformatorType = CurrentTransformatorType.TypeA, TransformerRatio = Ratio.CurrentTransformerRatioA, VerificationDate = new DateTime(2020, 10, 26), OutOfVerificationDate = new DateTime(2024, 11, 15), MeasuringPointId = 2 },
                new CurrentTransformer() { Number = 753, TransformatorType = CurrentTransformatorType.TypeB, TransformerRatio = Ratio.CurrentTransformerRatioB, VerificationDate = new DateTime(2018, 9, 12), OutOfVerificationDate = new DateTime(2020, 6, 26), MeasuringPointId = 3 },
                new CurrentTransformer() { Number = 1459, TransformatorType = CurrentTransformatorType.TypeA, TransformerRatio = Ratio.CurrentTransformerRatioC, VerificationDate = new DateTime(2018, 6, 27), OutOfVerificationDate = new DateTime(2023, 5, 6), MeasuringPointId = 4 },
                new CurrentTransformer() { Number = 1485, TransformatorType = CurrentTransformatorType.TypeB, TransformerRatio = Ratio.CurrentTransformerRatioB, VerificationDate = new DateTime(2020, 5, 25), OutOfVerificationDate = new DateTime(2020, 8, 6), MeasuringPointId = 5 },
                new CurrentTransformer() { Number = 963, TransformatorType = CurrentTransformatorType.TypeC, TransformerRatio = Ratio.CurrentTransformerRatioC, VerificationDate= new DateTime(2019, 4, 8), OutOfVerificationDate = new DateTime(2022, 4, 16), MeasuringPointId = 6 },
                new CurrentTransformer() { Number = 781, TransformatorType = CurrentTransformatorType.TypeA, TransformerRatio = Ratio.CurrentTransformerRatioA, VerificationDate = new DateTime(2017, 12, 30), OutOfVerificationDate = new DateTime(2022, 9, 17), MeasuringPointId = 7 },
                new CurrentTransformer() { Number = 126, TransformatorType = CurrentTransformatorType.TypeC, TransformerRatio = Ratio.CurrentTransformerRatioB, VerificationDate = new DateTime(2020, 4, 12), OutOfVerificationDate = new DateTime(2022, 12, 6), MeasuringPointId = 8 },
                new CurrentTransformer() { Number = 743, TransformatorType = CurrentTransformatorType.TypeC, TransformerRatio = Ratio.CurrentTransformerRatioC, VerificationDate = new DateTime(2020, 1, 10), OutOfVerificationDate = new DateTime(2021, 10, 6), MeasuringPointId = 9 },
                new CurrentTransformer() { Number = 9651, TransformatorType = CurrentTransformatorType.TypeB, TransformerRatio = Ratio.CurrentTransformerRatioA, VerificationDate = new DateTime(2020, 9, 6), OutOfVerificationDate = new DateTime(2022, 8, 6), MeasuringPointId = 10 },
                new CurrentTransformer() { Number = 8532, TransformatorType = CurrentTransformatorType.TypeA, TransformerRatio = Ratio.CurrentTransformerRatioB, VerificationDate = new DateTime(2020, 6, 4), OutOfVerificationDate = new DateTime(2022, 7, 6), MeasuringPointId = 11 },
                new CurrentTransformer() { Number = 1248, TransformatorType = CurrentTransformatorType.TypeB, TransformerRatio = Ratio.CurrentTransformerRatioC, VerificationDate = new DateTime(2021, 1, 12), OutOfVerificationDate = new DateTime(2022, 4, 4), MeasuringPointId = 12 },
                new CurrentTransformer() { Number = 265, TransformatorType = CurrentTransformatorType.TypeA, TransformerRatio = Ratio.CurrentTransformerRatioB, VerificationDate = new DateTime(2020, 8, 12), OutOfVerificationDate = new DateTime(2023, 3, 6), MeasuringPointId = 13 },
                new CurrentTransformer() { Number = 784, TransformatorType = CurrentTransformatorType.TypeC, TransformerRatio = Ratio.CurrentTransformerRatioA, VerificationDate = new DateTime(2020, 4, 19), OutOfVerificationDate = new DateTime(2022, 6, 6), MeasuringPointId = 14 },
                new CurrentTransformer() { Number = 672, TransformatorType = CurrentTransformatorType.TypeA, TransformerRatio = Ratio.CurrentTransformerRatioC, VerificationDate = new DateTime(2022, 10, 20), OutOfVerificationDate = new DateTime(2024, 6, 6), MeasuringPointId = 15 }
            };

            _conext.CurrentTransformers.AddRange(currentTransformers);
            await _conext.SaveChangesAsync(cancellationToken);
        }

        private async Task AddVoltageTransformers(CancellationToken cancellationToken)
        {
            var voltageTransformers = new List<VoltageTransformer>()
            {
                new VoltageTransformer() { Number = 1, TransformerType = VoltageTransformerType.TypeG, TransformerRatio = Ratio.VoltageTransformerRatioC, VerificationDate = new DateTime(2013, 2, 1), OutOfVerificationDate = new DateTime(2017, 2, 1), MeasuringPointId = 1 },
                new VoltageTransformer() { Number = 2, TransformerType = VoltageTransformerType.TypeF, TransformerRatio = Ratio.VoltageTransformerRatioA, VerificationDate = new DateTime(2015, 3, 12), OutOfVerificationDate = new DateTime(2018, 4, 16), MeasuringPointId = 2 },
                new VoltageTransformer() { Number = 3, TransformerType = VoltageTransformerType.TypeG, TransformerRatio = Ratio.VoltageTransformerRatioC, VerificationDate = new DateTime(2011, 5, 6), OutOfVerificationDate = new DateTime(2019, 3, 5), MeasuringPointId = 3 },
                new VoltageTransformer() { Number = 4, TransformerType = VoltageTransformerType.TypeH, TransformerRatio = Ratio.VoltageTransformerRatioB, VerificationDate = new DateTime(2019, 8, 13), OutOfVerificationDate = new DateTime(2022, 2, 2), MeasuringPointId = 4 },
                new VoltageTransformer() { Number = 51, TransformerType = VoltageTransformerType.TypeG, TransformerRatio = Ratio.VoltageTransformerRatioB, VerificationDate = new DateTime(2020, 12, 20), OutOfVerificationDate = new DateTime(2025, 6, 8), MeasuringPointId = 5 },
                new VoltageTransformer() { Number = 61, TransformerType = VoltageTransformerType.TypeF, TransformerRatio = Ratio.VoltageTransformerRatioC, VerificationDate = new DateTime(2023, 1, 29), OutOfVerificationDate = new DateTime(2027, 7, 1), MeasuringPointId = 6 },
                new VoltageTransformer() { Number = 71, TransformerType = VoltageTransformerType.TypeG, TransformerRatio = Ratio.VoltageTransformerRatioA, VerificationDate = new DateTime(2022, 1, 19), OutOfVerificationDate = new DateTime(2026, 1, 20), MeasuringPointId = 7 },
                new VoltageTransformer() { Number = 81, TransformerType = VoltageTransformerType.TypeH, TransformerRatio = Ratio.VoltageTransformerRatioC, VerificationDate = new DateTime(2018, 7, 24), OutOfVerificationDate = new DateTime(2023, 7, 25), MeasuringPointId = 8 },
                new VoltageTransformer() { Number = 91, TransformerType = VoltageTransformerType.TypeG, TransformerRatio = Ratio.VoltageTransformerRatioB, VerificationDate = new DateTime(2016, 6, 15), OutOfVerificationDate = new DateTime(2020, 4, 11), MeasuringPointId = 9 },
                new VoltageTransformer() { Number = 101, TransformerType = VoltageTransformerType.TypeG, TransformerRatio = Ratio.VoltageTransformerRatioA, VerificationDate = new DateTime(2014, 10, 11), OutOfVerificationDate = new DateTime(2018, 11, 11), MeasuringPointId = 10 },
                new VoltageTransformer() { Number = 201, TransformerType = VoltageTransformerType.TypeF, TransformerRatio = Ratio.VoltageTransformerRatioB, VerificationDate = new DateTime(2018, 2, 1), OutOfVerificationDate = new DateTime(2023, 2, 2), MeasuringPointId = 11 },
                new VoltageTransformer() { Number = 31, TransformerType = VoltageTransformerType.TypeG, TransformerRatio = Ratio.VoltageTransformerRatioC, VerificationDate = new DateTime(2015, 4, 2), OutOfVerificationDate = new DateTime(2020, 5, 1), MeasuringPointId = 12 },
                new VoltageTransformer() { Number = 41, TransformerType = VoltageTransformerType.TypeH, TransformerRatio = Ratio.VoltageTransformerRatioA, VerificationDate = new DateTime(2019, 11, 12), OutOfVerificationDate = new DateTime(2022, 10, 11), MeasuringPointId = 13 },
                new VoltageTransformer() { Number = 561, TransformerType = VoltageTransformerType.TypeG, TransformerRatio = Ratio.VoltageTransformerRatioC, VerificationDate = new DateTime(2020, 12, 1), OutOfVerificationDate = new DateTime(2024, 11, 1), MeasuringPointId = 14 },
                new VoltageTransformer() { Number = 631, TransformerType = VoltageTransformerType.TypeF, TransformerRatio = Ratio.VoltageTransformerRatioB, VerificationDate = new DateTime(2023, 2, 4), OutOfVerificationDate = new DateTime(2026, 2, 2), MeasuringPointId = 15 }
            };

            _conext.VoltageTransformers.AddRange(voltageTransformers);
            await _conext.SaveChangesAsync(cancellationToken);
        }

        private async Task AddMeteringDevices(CancellationToken cancellationToken)
        {
            var meteringDevices = new List<MeteringDevice>()
            {
                new MeteringDevice() { MeasuringPointId = 1, DeliveryPointId = 1, StartDate = new DateTime(2017, 2, 1), EndDate = new DateTime(2019, 2, 1)},
                new MeteringDevice() { MeasuringPointId = 1, DeliveryPointId = 2, StartDate = new DateTime(2018, 4, 3), EndDate = new DateTime(2020, 3, 2)},
                new MeteringDevice() { MeasuringPointId = 2, DeliveryPointId = 1, StartDate = new DateTime(2020, 1, 16), EndDate = new DateTime(2021, 5, 3)},
                new MeteringDevice() { MeasuringPointId = 2, DeliveryPointId = 3, StartDate = new DateTime(2011, 3, 19), EndDate = new DateTime(2015, 4, 4)},
                new MeteringDevice() { MeasuringPointId = 2, DeliveryPointId = 4, StartDate = new DateTime(2021, 5, 22), EndDate = new DateTime(2025, 6, 5)},
                new MeteringDevice() { MeasuringPointId = 3, DeliveryPointId = 3, StartDate = new DateTime(2018, 5, 24), EndDate = new DateTime(2020, 7, 6)},
                new MeteringDevice() { MeasuringPointId = 4, DeliveryPointId = 5, StartDate = new DateTime(2018, 6, 29), EndDate = new DateTime(2023, 8, 7)},
                new MeteringDevice() { MeasuringPointId = 5, DeliveryPointId = 5, StartDate = new DateTime(2019, 8, 13), EndDate = new DateTime(2020, 9, 8)},
                new MeteringDevice() { MeasuringPointId = 6, DeliveryPointId = 8, StartDate = new DateTime(2023, 2, 4), EndDate = new DateTime(2026, 10, 9)},
                new MeteringDevice() { MeasuringPointId = 9, DeliveryPointId = 7, StartDate = new DateTime(2022, 1, 18), EndDate = new DateTime(2022, 11, 10)}
            };

            _conext.MeteringDevices.AddRange(meteringDevices);
            await _conext.SaveChangesAsync(cancellationToken);
        }

    }
}
