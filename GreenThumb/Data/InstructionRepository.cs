using GreenThumb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenThumb.Data
{
    public class InstructionRepository
    {
        private readonly GreenThumbDbContext _context;

        public InstructionRepository(GreenThumbDbContext context)
        {
            _context = context;
        }

        public List<InstructionModel> GetInstructionsOfPlant(int plantId) 
        {
            return _context.Instruction.Where(i => i.PlantId == plantId).ToList();  
        }
    }
}
