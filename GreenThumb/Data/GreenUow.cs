using GreenThumb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenThumb.Data
{
    public class GreenUow
    {
        private readonly GreenThumbDbContext _context;


        //NOT Generic REPO
        public InstructionRepository InstructionRepo { get; }
        public GardenRepository GardenRepo { get; }

        public GreenUow(GreenThumbDbContext context)
        {
            _context = context;
            
            InstructionRepo = new(context);
            GardenRepo = new(context);
        }

        public void SaveChanges() 
        {
            _context.SaveChanges();
        }
    }
}
