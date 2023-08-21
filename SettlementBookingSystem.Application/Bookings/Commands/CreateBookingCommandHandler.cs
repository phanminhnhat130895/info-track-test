using MediatR;
using SettlementBookingSystem.Application.Bookings.Dtos;
using SettlementBookingSystem.Application.Exceptions;
using SettlementBookingSystem.Application.Helper;
using SettlementBookingSystem.Infrastructure.Data;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SettlementBookingSystem.Application.Bookings.Commands
{
    public class CreateBookingCommandHandler : IRequestHandler<CreateBookingCommand, BookingDto>
    {
        public CreateBookingCommandHandler()
        {
            
        }

        public async Task<BookingDto> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
        {
            var countConflictBooking = BookingContext.TableBooking.Count(b => (TimeHelper.ConvertFromHHMM(b.BookingTime) <= TimeHelper.ConvertFromHHMM(request.BookingTime) && 
                                                                              TimeHelper.ConvertFromHHMM(request.BookingTime) <= TimeHelper.ConvertFromHHMM(b.BookingTime).AddMinutes(59)) ||
                                                                              (TimeHelper.ConvertFromHHMM(b.BookingTime) <= TimeHelper.ConvertFromHHMM(request.BookingTime).AddMinutes(59) &&
                                                                              TimeHelper.ConvertFromHHMM(request.BookingTime).AddMinutes(59) <= TimeHelper.ConvertFromHHMM(b.BookingTime).AddMinutes(59)));

            if (countConflictBooking > 3)
            {
                throw new ConflictException("Booking Conflict");
            }

            var bookingDto = new BookingDto();

            Domain.Entities.Bookings booking = new Domain.Entities.Bookings(bookingDto.BookingId);
            booking.Name = request.Name;
            booking.BookingTime = request.BookingTime;
            booking.DateCreated = DateTime.Now;

            BookingContext.TableBooking.Add(booking);

            return bookingDto;
        }
    }
}
