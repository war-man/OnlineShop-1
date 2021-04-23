using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShopOnline.Application.InterfaceAPI;
using ShopOnline.Data;
using ShopOnline.Data.Entity;
using ShopOnline.Model.LanguageModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.ImplementationAPI
{
    public class LanguageSerVice : ILanguageSerVice
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        public LanguageSerVice(ApplicationDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<List<LanguageViewModel>> GetAll()
        {
            var list = await _context.Languages.ToListAsync();
            var listlanguageViewModel = _mapper.Map<List<Language>, List<LanguageViewModel>>(list);
            return listlanguageViewModel;
        }
    }
}
