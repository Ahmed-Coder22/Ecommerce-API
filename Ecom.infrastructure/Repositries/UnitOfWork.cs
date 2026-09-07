using AutoMapper;
using Ecom.Core.Entities;
using Ecom.Core.interfaces;
using Ecom.Core.Services;
using Ecom.infrastructure.Data;
using Ecom.infrastructure.Repositries.Services;
using Microsoft.AspNetCore.Identity;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.infrastructure.Repositries
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IImageManagementService _imageManagementService;
        private readonly UserManager<AppUser> userManager;
        private readonly IEmailService emailService;
        private readonly SignInManager<AppUser> signInManager;
        private readonly IGenerateToken token;
        public ICategoryRepositry CategoryRepositry { get; }

        public IPhotoRepositry PhotoRepositry { get; }

        public IProductRepositry productRepositry { get; }


        public ICustomerBasketRepositry CustomerBasketRepositry { get; }

        public IAuth Auth{get; }

        public UnitOfWork(AppDbContext context, IMapper mapper, IImageManagementService imageManagementService, IConnectionMultiplexer redis, UserManager<AppUser> userManager,
            IEmailService emailService, SignInManager<AppUser> signInManager
, IGenerateToken token)
        {
            _context = context;
            _mapper = mapper;
            _imageManagementService = imageManagementService;
            this.userManager = userManager;
            this.emailService = emailService;
            this.signInManager = signInManager;
            this.token = token;
            CategoryRepositry = new CategoryRepositry(_context);
            PhotoRepositry = new PhotoRepositry(_context);
            productRepositry = new ProductRepositry(_context, _mapper, _imageManagementService);
            CustomerBasketRepositry = new CustomerBasketRepositry(redis);
            Auth = new AuthRepositry(userManager, signInManager, emailService,token,context);
        }
    }
}
