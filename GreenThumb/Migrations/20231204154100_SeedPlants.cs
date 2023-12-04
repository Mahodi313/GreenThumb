using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GreenThumb.Migrations
{
    public partial class SeedPlants : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Plants",
                columns: new[] { "plant_id", "description", "name" },
                values: new object[,]
                {
                    { 1, "The rose, a timeless symbol of love and beauty, charms with its thorny stems and a variety of velvety, fragrant blossoms in hues from deep red to soft pink and pure white.", "Rose" },
                    { 2, "Aloe vera, a succulent marvel, boasts lance-shaped leaves forming a graceful rosette. Its plump, serrated foliage contains a soothing gel, blending beauty with healing virtues.", "Aloe Vera" },
                    { 3, "Maple trees, with their vibrant autumnal attire, paint the landscape in hues of fiery reds, golden yellows, and burnt oranges. Graceful and iconic, their distinctively lobed leaves dance in the breeze, turning each fall day into a masterpiece of nature's artistry.", "Maple Tree" },
                    { 4, "Cacti, resilient desert sculptures, wear spines like jewels, a testament to their enduring beauty in arid landscapes.", "Cacti" },
                    { 5, "Sunflowers, nature's radiant sentinels, boast golden crowns that mirror the sun's warmth. Their towering stems, adorned with sunny faces, sway in rhythmic dance, embodying a field of boundless optimism and natural splendor.", "Sun Flower" },
                    { 6, "Bamboo, a serene symphony of strength and grace, paints landscapes with its emerald elegance. With slender stems reaching for the sky, it whispers tales of resilience and versatility, a tranquil poetry etched in green.", "Bamboo" },
                    { 7, "Palm trees, nature's ambassadors of paradise, stand tall with graceful fronds that rustle like whispers in the tropical breeze, embodying an eternal holiday under the sun.", "Palm Tree" },
                    { 8, "Lilies, nature's elegant muses, unfurl their petals in a ballet of grace, each blossom a masterpiece of delicate allure, inviting admiration with their timeless beauty and enchanting fragrance.", "Lily" },
                    { 9, "Orchids, ethereal dancers of the plant kingdom, grace the world with intricate blooms, a testament to nature's artistry, each blossom a delicate masterpiece, capturing hearts with their exotic allure.", "Orchid" },
                    { 10, "Succulents, nature's resilient jewels, adorn arid landscapes with their plump leaves, a mosaic of vibrant hues. These water-wise wonders, sculpted by sunlight, whisper tales of endurance and beauty in the harshest of climates.", "Succulent" },
                    { 11, "Lavender, a fragrant symphony in purple, weaves a tapestry of calm. Its slender stems carry blossoms that release a soothing aroma, inviting tranquility and a touch of nature's elegance to any landscape.", "Lavender" },
                    { 12, "Tulips, nature's ephemeral flames, burst forth in a kaleidoscope of colors, painting the world with their vibrant petals. These graceful blooms, standing tall in a symphony of hues, epitomize the fleeting beauty of spring.", "Tulip" },
                    { 13, "Ferns, nature's verdant lace, unfurl delicate fronds in a graceful dance. Their lush foliage, a testament to ancient elegance, brings a touch of timeless beauty to shaded retreats.", "Ferns" },
                    { 14, "Bonsai trees, miniature emperors of serenity, embody the essence of nature in a pint-sized universe. With meticulously pruned branches and whispered stories of resilience, each tiny masterpiece breathes tranquility into its petite realm.", "Bonsai Tree" },
                    { 15, "Arctic Willow, a whispering ballerina of the tundra, graces the icy landscape with its delicate, silvery branches. Amidst the frozen expanse, it stands as a testament to nature's ability to find grace and beauty in the harshest climates.", "Arctic Willow" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Plants",
                keyColumn: "plant_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Plants",
                keyColumn: "plant_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Plants",
                keyColumn: "plant_id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Plants",
                keyColumn: "plant_id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Plants",
                keyColumn: "plant_id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Plants",
                keyColumn: "plant_id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Plants",
                keyColumn: "plant_id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Plants",
                keyColumn: "plant_id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Plants",
                keyColumn: "plant_id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Plants",
                keyColumn: "plant_id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Plants",
                keyColumn: "plant_id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Plants",
                keyColumn: "plant_id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Plants",
                keyColumn: "plant_id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Plants",
                keyColumn: "plant_id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Plants",
                keyColumn: "plant_id",
                keyValue: 15);
        }
    }
}
