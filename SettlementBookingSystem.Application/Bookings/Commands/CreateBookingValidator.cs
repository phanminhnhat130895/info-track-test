using FluentValidation;
using SettlementBookingSystem.Application.Helper;
using System;

namespace SettlementBookingSystem.Application.Bookings.Commands
{
    public class CreateBookingValidator : AbstractValidator<CreateBookingCommand>
    {
        public CreateBookingValidator()
        {
            RuleFor(b => b.Name).NotEmpty().WithMessage("'Name' is required.");
            RuleFor(b => b.BookingTime).Matches("[0-9]{1,2}:[0-9][0-9]").WithMessage("'Booking Time' is not in the correct format.")
                                       .Must(d => TimeSpan.TryParse(d, out TimeSpan result)).WithMessage("'Booking Time' is invalid.")
                                       .Must(d => TimeHelper.ConvertFromHHMM("08:59") < TimeHelper.ConvertFromHHMM(d) && TimeHelper.ConvertFromHHMM(d) < TimeHelper.ConvertFromHHMM("16:01")).WithMessage("'Booking Time' is out of hours times.");
        }
    }
}
