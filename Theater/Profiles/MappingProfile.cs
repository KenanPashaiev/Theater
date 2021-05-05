using AutoMapper;
using Theater.BL.Models.Booking;
using Theater.BL.Models.Hall;
using Theater.BL.Models.Note;
using Theater.BL.Models.Session;
using Theater.BL.Models.Transaction;
using Theater.BL.Models.User;
using Theater.Models;

namespace Theater.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<UserRegisterDto, User>();
            CreateMap<UserLoginDto, User>();

            CreateMap<Booking, BookingDto>().ReverseMap();
            CreateMap<BookingCreateDto, Booking>();
            CreateMap<BookingUpdateDto, Booking>();

            CreateMap<Hall, HallDto>().ReverseMap();
            CreateMap<HallCreateDto, Hall>(); 
            CreateMap<HallUpdateDto, Hall>();
            CreateMap<HallSection, HallSectionDto>().ReverseMap();
            CreateMap<HallSectionCreateUpdateDto, HallSection>();

            CreateMap<Note, NoteDto>().ReverseMap();
            CreateMap<NoteCreateUpdateDto, Note>();

            CreateMap<Session, SessionDto>().ReverseMap();
            CreateMap<SessionCreateUpdateDto, Session>();

            CreateMap<Transaction, TransactionDto>().ReverseMap();
            CreateMap<TransactionCreateDto, Transaction>();
        }
    }
}
