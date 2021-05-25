using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Booking.BusinessLayer.Abstract;
using Booking.Dto;
using Booking.DataLayer.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Booking.BusinessLayer.Services
{
    public class HotelService : IHotelService
    {
        /*
         Нужно выделить отдельный класс для BookingContext так как контекст у нас
         не меняется и мы копируем код, нужно сделать реализовать dependency injection
         (Возможно для маппера тоже) !!
        */

        // ВНИМАНИЕ ОТВЕТ!
        // иначе вы класс BookingContext должны будете постоянно реализовавывать
        // как и говорил ранее, для более удобного контроля вы можете создать дополнительную абстракцию
        // почитайте про паттерны: Repository, GenericRepository, UnitOfWork 
        
        // Так же вы можете создать базовый класс BaseService
        // и инициализировать BookingContext и IMapper туда,
        // а все остльные классы можете наследовать вместе с контекстом
        // (Просто как варик, хотя тоже гавнокод XD)
        
        // это и есть DI
        private readonly BookingContext _context;
        
        // это и есть DI
        private readonly IMapper _mapper;
        
        public HotelService(BookingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Hotel>> GetHotelsAsync()
        {
            var domainHotels = await _context.Hotels.ToListAsync();
            var hotels = _mapper.Map<IEnumerable<Hotel>>(domainHotels);
            return hotels;
        }

        // вот такие методы вроде CRUD, может выделить в отедльный Generic класс и на основе шаблона рабоать с моделями
        // чтобы все время не переписывать методы
        // код часто повторяется
        
        public async Task<Guid> CreateHotelAsync(Hotel hotel)
        {
            var domainHotel = _mapper.Map<DataLayer.Tables.Hotels.Hotel>(hotel);
            domainHotel.ModifiedAt = DateTime.Now;
            domainHotel.ModifiedBy = "admin";
            domainHotel.ModifyReason = "creation";
            
            await _context.Hotels.AddAsync(domainHotel);
            await _context.SaveChangesAsync();
            return domainHotel.Id;
        }

        public async Task<Hotel> EditHotelAsync(Hotel hotel)
        {
            var domainHotel = _mapper.Map<DataLayer.Tables.Hotels.Hotel>(hotel);
            domainHotel.ModifiedAt = DateTime.Now;
            domainHotel.ModifiedBy = "admin";
            domainHotel.ModifyReason = "editing";
            
            _context.Hotels.Update(domainHotel);
            await _context.SaveChangesAsync();
            var dtoHotel = _mapper.Map<Hotel>(domainHotel);
            return dtoHotel;
        }

        
        public async Task<IEnumerable<Service>> GetServicesAsync(Guid hotelId)
        {
            var domainServices = await _context.Services
                .Where(x => x.HotelId == hotelId)
                .OrderBy(x => x.Price).ToListAsync();
            var dtoServices = _mapper.Map<IEnumerable<Service>>(domainServices);
            return dtoServices;
        }

        public async Task<Service> CreateServiceAsync(Service service)
        {
            var domainService = _mapper.Map<DataLayer.Tables.Hotels.Service>(service);
            domainService.ModifiedAt = DateTime.Now;
            domainService.ModifiedBy = "admin";
            domainService.ModifyReason = "creation";
            
            await _context.Services.AddAsync(domainService);
            await _context.SaveChangesAsync();
            var dtoService = _mapper.Map<Service>(domainService);
            return dtoService;
        }

        public async Task<Service> EditServiceAsync(Service service)
        {
            var domainService = _mapper.Map<DataLayer.Tables.Hotels.Service>(service);
            domainService.ModifiedAt = DateTime.Now;
            domainService.ModifiedBy = "admin";
            domainService.ModifyReason = "editing";
            
            _context.Services.Update(domainService);
            await _context.SaveChangesAsync();
            var dtoService = _mapper.Map<Service>(domainService);
            return dtoService;
        }
    }
}