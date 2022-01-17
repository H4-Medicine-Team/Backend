using AutoMapper;
using MedicineApi.Models;
using System;

namespace MedicineApi.Profiles
{
    public class MedicineProfile : Profile
    {
        public MedicineProfile()
        {
            // Models
            CreateMap<DataAccess.Dtos.Day, DayOfWeek[]>()
                .ConvertUsing(new BoolConvertToDayOfWeek());

            // Dto
            CreateMap<Dosage, DataAccess.Dtos.Dosage>()
                .ForMember(d => d.AmountType, opt => opt.MapFrom(src => src.AmountType))
                .ForMember(d => d.Id, opt => opt.MapFrom(src => src.Id));

            CreateMap<Interval, DataAccess.Dtos.Interval>()
                .ForMember(d => d.StartTime, opt => opt.MapFrom(src => src.Start))
                .ForMember(d => d.EndTime, opt => opt.MapFrom(src => src.End))
                .ForMember(d => d.ConsumptionTime, opt => opt.MapFrom(src => src.ConsumptionTime.TimeOfDay));

            CreateMap<DayOfWeek[], DataAccess.Dtos.Day>()
                .ConvertUsing(new DayConverter());
        }

        private class DayConverter : ITypeConverter<DayOfWeek[], DataAccess.Dtos.Day>
        {
            public DataAccess.Dtos.Day Convert(DayOfWeek[] source, DataAccess.Dtos.Day destination, ResolutionContext context)
            {
                DataAccess.Dtos.Day dat = new DataAccess.Dtos.Day();

                foreach (var d in source)
                {
                    switch (d)
                    {
                        case DayOfWeek.Monday:
                            dat.Monday = true;
                            break;
                        case DayOfWeek.Tuesday:
                            dat.Tuesday = true;
                            break;
                        case DayOfWeek.Wednesday:
                            dat.Wednesday = true;
                            break;
                        case DayOfWeek.Thursday:
                            dat.Thursday = true;
                            break;
                        case DayOfWeek.Friday:
                            dat.Friday = true;
                            break;
                        case DayOfWeek.Saturday:
                            dat.Saturday = true;
                            break;
                        case DayOfWeek.Sunday:
                            dat.Sunday = true;
                            break;
                        default:
                            break;
                    };
                }

                return dat;
            }
        }

        private class BoolConvertToDayOfWeek : ITypeConverter<DataAccess.Dtos.Day, DayOfWeek[]>
        {
            public DayOfWeek[] Convert(DataAccess.Dtos.Day source, DayOfWeek[] destination, ResolutionContext context)
            {
                DayOfWeek[] days = new DayOfWeek[7];
                if (source.Sunday == true)
                    days[0] = DayOfWeek.Sunday;
                if (source.Monday == true)
                    days[1] = DayOfWeek.Monday;
                if (source.Tuesday == true)
                    days[2] = DayOfWeek.Tuesday;
                if (source.Wednesday == true)
                    days[3] = DayOfWeek.Wednesday;
                if (source.Thursday == true)
                    days[4] = DayOfWeek.Thursday;
                if (source.Friday == true)
                    days[5] = DayOfWeek.Friday;
                if (source.Saturday == true)
                    days[6] = DayOfWeek.Saturday;
                return days;
            }
        }
    }
}
