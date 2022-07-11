using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travel.DAL.Infrastructure;
using Travel.DAL.Models;
using Travel.BLL.Interfaces;
using Travel.BLL.Dtos.Flight;
using System;

namespace Travel.BLL.Services
{
    public class FlightService : IFlightService
    {
        private readonly TravelContext _context;

        public FlightService(TravelContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GetFlightDto>> GetAllFlights()
        {
            var flights = await _context.TravelFlights
                .Where(i => i.IsDeleted == false)
                .Select(i => new GetFlightDto
                {
                    TripId = i.TripId,
                    FlightNumber = i.FlightNumber,
                    AirlineName = i.AirlineName,
                    DepartureAirportName = i.DepartureAirportName,
                    ArrivalAirportName = i.ArrivalAirportName,
                    StartLocation = i.StartLocation,
                    EndLocation = i.EndLocation,
                    DepartureTime = i.DepartureTime,
                    ArrivalTime = i.ArrivalTime,
                    ConfirmationCode = i.ConfirmationCode,
                    Notes = i.Notes
                })
                .AsNoTracking()
                .ToListAsync();

            return flights;
        }

        public async Task<IEnumerable<GetFlightDto>> GetFlightsByTrip(int id)
        {
            var flights = await _context.TravelFlights
                .Where(i => i.TripId == id)
                .Where(i => i.IsDeleted == false)
                .Select(i => new GetFlightDto
                {
                    TripId = i.TripId,
                    FlightNumber = i.FlightNumber,
                    AirlineName = i.AirlineName,
                    DepartureAirportName = i.DepartureAirportName,
                    ArrivalAirportName = i.ArrivalAirportName,
                    StartLocation = i.StartLocation,
                    EndLocation = i.EndLocation,
                    DepartureTime = i.DepartureTime,
                    ArrivalTime = i.ArrivalTime,
                    ConfirmationCode = i.ConfirmationCode,
                    Notes = i.Notes
                })
                .AsNoTracking()
                .ToListAsync();

            return flights;
        }

        public async Task<GetFlightDto> GetFlightByFlightID(int id)
        {
            var flight = await _context.TravelFlights
                .Where(i => i.FlightId == id)
                .Where(i => i.IsDeleted == false)
                .Select(i => new GetFlightDto
                {
                    TripId = i.TripId,
                    FlightNumber = i.FlightNumber,
                    AirlineName = i.AirlineName,
                    DepartureAirportName = i.DepartureAirportName,
                    ArrivalAirportName = i.ArrivalAirportName,
                    StartLocation = i.StartLocation,
                    EndLocation = i.EndLocation,
                    DepartureTime = i.DepartureTime,
                    ArrivalTime = i.ArrivalTime,
                    ConfirmationCode = i.ConfirmationCode,
                    Notes = i.Notes
                })
                .AsNoTracking()
                .FirstOrDefaultAsync();

            return flight;
        }

        public async Task<bool> CreateFlight(CreateFlightDto flightDto)
        {
            if(flightDto == null)
            {
                return false;
            }

            var flight = new Flight
            {
                TripId = flightDto.TripId,
                FlightNumber = flightDto.FlightNumber,
                AirlineName = flightDto.AirlineName,
                DepartureAirportName = flightDto.DepartureAirportName,
                ArrivalAirportName = flightDto.ArrivalAirportName,
                StartLocation = flightDto.StartLocation,
                EndLocation = flightDto.EndLocation,
                DepartureTime = flightDto.DepartureTime,
                ArrivalTime = flightDto.ArrivalTime,
                ConfirmationCode = flightDto.ConfirmationCode,
                Notes = flightDto.Notes,
                IsDeleted = false,
                IsEnabled = true,
                CreatedDate = DateTime.UtcNow,
                ModifiedDate = DateTime.UtcNow
            };

            _context.TravelFlights.Add(flight);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateFlight(UpdateFlightDto flightDto)
        {
            if(flightDto == null)
            {
                return false;
            }

            var flight = await _context.TravelFlights
                .Where(i => i.FlightId == flightDto.Id)
                .FirstOrDefaultAsync();

            if(flight == null)
            {
                return false;
            }

            flight.TripId = flightDto.TripId;
            flight.FlightNumber = flightDto.FlightNumber;
            flight.AirlineName = flightDto.AirlineName;
            flight.DepartureAirportName = flightDto.DepartureAirportName;
            flight.ArrivalAirportName = flightDto.ArrivalAirportName;
            flight.StartLocation = flightDto.StartLocation;
            flight.EndLocation = flightDto.EndLocation;
            flight.DepartureTime = flightDto.DepartureTime;
            flight.ArrivalTime = flightDto.ArrivalTime;
            flight.ConfirmationCode = flightDto.ConfirmationCode;
            flight.Notes = flightDto.Notes;
            flight.ModifiedDate = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteFlight(int id)
        {
            var flight = await _context.TravelFlights
                .Where(i => i.FlightId == id)
                .FirstOrDefaultAsync();

            if (flight == null)
            {
                return false;
            }

            flight.IsDeleted = true;
            flight.IsEnabled = false;

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
