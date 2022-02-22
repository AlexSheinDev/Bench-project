using AutoMapper;
using Bench_Business.Repository.IRepository;
using Bench_DataAccess;
using Bench_DataAccess.Data;
using Bench_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bench_Business.Repository
{
    public class ItemRepository : IItemRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public ItemRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public ItemDTO Create(ItemDTO objDTO)
        {
            var obj = _mapper.Map<ItemDTO, Item>(objDTO);
            obj.CreatedAt = DateTime.Now;

            var addedObj = _db.Items.Add(obj);
            _db.SaveChanges();

            return _mapper.Map<Item, ItemDTO>(addedObj.Entity);
        }

        public int Delete(int id)
        {
            var obj = _db.Items.FirstOrDefault(a => a.Id == id);

            if (obj != null)
            {
                _db.Items.Remove(obj);
                return _db.SaveChanges();
            }

            return 0;
        }

        public ItemDTO Get(int id)
        {
            var obj = _db.Items.FirstOrDefault(a => a.Id == id);

            if (obj != null)
            {
                return _mapper.Map<Item, ItemDTO>(obj);
            }

            return new ItemDTO();
        }

        public async Task<IEnumerable<ItemDTO>> GetAll()
        {
            return _mapper.Map<IEnumerable<Item>, IEnumerable<ItemDTO>>(_db.Items);
        }

        public ItemDTO Update(ItemDTO objDTO)
        {
            var objFromDb = _db.Items.FirstOrDefault(a => a.Id == objDTO.Id);

            if (objFromDb != null)
            {
                objFromDb.Name = objDTO.Name;
                _db.Items.Update(objFromDb);
                _db.SaveChanges();

                return _mapper.Map<Item, ItemDTO>(objFromDb);
            }

            return objDTO;
        }
    }
}
