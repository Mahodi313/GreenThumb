using GreenThumb.Models;
using Microsoft.EntityFrameworkCore;

namespace GreenThumb.Data
{
    public class GreenThumbDbContext : DbContext
    {
        public GreenThumbDbContext()
        {

        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<GardenModel> Gardens { get; set; }
        public DbSet<PlantModel> Plants { get; set; }
        public DbSet<InstructionModel> Instruction { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=GreenThumbDb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PlantModel>().HasData(
            new PlantModel()
            {
                PlantId = 1,
                Name = "Rose",
                Description = "The rose, a timeless symbol of love and beauty, charms with its thorny stems and a variety of velvety, fragrant blossoms in hues from deep red to soft pink and pure white."
            },
            new PlantModel()
            {
                PlantId = 2,
                Name = "Aloe Vera",
                Description = "Aloe vera, a succulent marvel, boasts lance-shaped leaves forming a graceful rosette. Its plump, serrated foliage contains a soothing gel, blending beauty with healing virtues."
            },
            new PlantModel() 
            {
                PlantId = 3,
                Name = "Maple Tree",
                Description = "Maple trees, with their vibrant autumnal attire, paint the landscape in hues of fiery reds, golden yellows, and burnt oranges. Graceful and iconic, their distinctively lobed leaves dance in the breeze, turning each fall day into a masterpiece of nature's artistry."
            },
            new PlantModel() 
            {
                PlantId = 4,
                Name = "Cacti",
                Description = "Cacti, resilient desert sculptures, wear spines like jewels, a testament to their enduring beauty in arid landscapes."
            },
            new PlantModel()
            {
                PlantId = 5,
                Name = "Sun Flower",
                Description = "Sunflowers, nature's radiant sentinels, boast golden crowns that mirror the sun's warmth. Their towering stems, adorned with sunny faces, sway in rhythmic dance, embodying a field of boundless optimism and natural splendor."
            },
            new PlantModel() 
            {
                PlantId = 6,
                Name = "Bamboo",
                Description = "Bamboo, a serene symphony of strength and grace, paints landscapes with its emerald elegance. With slender stems reaching for the sky, it whispers tales of resilience and versatility, a tranquil poetry etched in green."

            },
            new PlantModel() 
            {
                PlantId = 7,
                Name = "Palm Tree",
                Description = "Palm trees, nature's ambassadors of paradise, stand tall with graceful fronds that rustle like whispers in the tropical breeze, embodying an eternal holiday under the sun."

            },
            new PlantModel() 
            {
                PlantId = 8,
                Name = "Lily",
                Description = "Lilies, nature's elegant muses, unfurl their petals in a ballet of grace, each blossom a masterpiece of delicate allure, inviting admiration with their timeless beauty and enchanting fragrance."
            },
            new PlantModel() 
            {
                PlantId = 9,
                Name = "Orchid",
                Description = "Orchids, ethereal dancers of the plant kingdom, grace the world with intricate blooms, a testament to nature's artistry, each blossom a delicate masterpiece, capturing hearts with their exotic allure."
            },
            new PlantModel() 
            {
                PlantId = 10,
                Name = "Succulent",
                Description = "Succulents, nature's resilient jewels, adorn arid landscapes with their plump leaves, a mosaic of vibrant hues. These water-wise wonders, sculpted by sunlight, whisper tales of endurance and beauty in the harshest of climates."
            },
            new PlantModel() 
            {
                PlantId = 11,
                Name = "Lavender",
                Description = "Lavender, a fragrant symphony in purple, weaves a tapestry of calm. Its slender stems carry blossoms that release a soothing aroma, inviting tranquility and a touch of nature's elegance to any landscape."
            },
            new PlantModel() 
            {
                PlantId = 12,
                Name = "Tulip",
                Description = "Tulips, nature's ephemeral flames, burst forth in a kaleidoscope of colors, painting the world with their vibrant petals. These graceful blooms, standing tall in a symphony of hues, epitomize the fleeting beauty of spring."
            },
            new PlantModel() 
            {
                PlantId = 13,
                Name = "Ferns",
                Description = "Ferns, nature's verdant lace, unfurl delicate fronds in a graceful dance. Their lush foliage, a testament to ancient elegance, brings a touch of timeless beauty to shaded retreats."

            },
            new PlantModel() 
            {
                 PlantId = 14,
                 Name = "Bonsai Tree",
                 Description = "Bonsai trees, miniature emperors of serenity, embody the essence of nature in a pint-sized universe. With meticulously pruned branches and whispered stories of resilience, each tiny masterpiece breathes tranquility into its petite realm."
            },
            new PlantModel() 
            {
                PlantId = 15,
                Name = "Arctic Willow",
                Description = "Arctic Willow, a whispering ballerina of the tundra, graces the icy landscape with its delicate, silvery branches. Amidst the frozen expanse, it stands as a testament to nature's ability to find grace and beauty in the harshest climates."
            });
        }
    }
}
