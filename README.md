# SettlementBookingTest

## Versions

1. Mediator Implementation

`BookingController` provides an implementation using the mediator pattern and the data is stored in an [Interval Tree](https://en.wikipedia.org/wiki/Interval_tree) for O(log m + n) access.
This implementatrion also provides unit tests with a mocked repository.

## How to execute

1. Mediator

```
curl --request POST \
  --url https://localhost:44355/Booking \
  --header 'Content-Type: application/json' \
  --data '{
	"bookingTime": "09:30",
	"name": "John"
}'
```
