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
            

            // Dto
            CreateMap<Dosage, DataAccess.Dtos.Dosage>()
                .ForMember(d => d.AmountTypeId, opt => opt.MapFrom(src => (int)src.AmountType));

            CreateMap<AmountType, DataAccess.Dtos.AmountType>()
                .ForMember(d => d.Id, opt => opt.MapFrom(src => (int)src))
                .ForMember(d => d.Name, opt => opt.MapFrom(src => src.ToString()));

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
    }
}
