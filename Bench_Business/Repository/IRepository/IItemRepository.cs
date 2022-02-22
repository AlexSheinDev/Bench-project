using Bench_Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bench_Business.Repository.IRepository
{
    public interface IItemRepository
    {
        public ItemDTO Create(ItemDTO objDTO);
        public ItemDTO Update(ItemDTO objDTO);
        public int Delete(int id);
        public ItemDTO Get(int id);
        public Task<IEnumerable<ItemDTO>> GetAll();
    }
}
