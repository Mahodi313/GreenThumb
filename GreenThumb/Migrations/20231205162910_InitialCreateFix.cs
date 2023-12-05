using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GreenThumb.Migrations
{
    public partial class InitialCreateFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Plants",
                columns: table => new
                {
                    plant_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plants", x => x.plant_id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    is_admin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "Instructions",
                columns: table => new
                {
                    instruction_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    plant_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructions", x => x.instruction_id);
                    table.ForeignKey(
                        name: "FK_Instructions_Plants_plant_id",
                        column: x => x.plant_id,
                        principalTable: "Plants",
                        principalColumn: "plant_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Gardens",
                columns: table => new
                {
                    garden_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gardens", x => x.garden_id);
                    table.ForeignKey(
                        name: "FK_Gardens_Users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "GardenModelPlantModel",
                columns: table => new
                {
                    GardensGardenId = table.Column<int>(type: "int", nullable: false),
                    PlantsPlantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GardenModelPlantModel", x => new { x.GardensGardenId, x.PlantsPlantId });
                    table.ForeignKey(
                        name: "FK_GardenModelPlantModel_Gardens_GardensGardenId",
                        column: x => x.GardensGardenId,
                        principalTable: "Gardens",
                        principalColumn: "garden_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GardenModelPlantModel_Plants_PlantsPlantId",
                        column: x => x.PlantsPlantId,
                        principalTable: "Plants",
                        principalColumn: "plant_id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.InsertData(
                table: "Instructions",
                columns: new[] { "instruction_id", "description", "name", "plant_id" },
                values: new object[,]
                {
                    { 1, "Deep and infrequent watering rather than frequent shallow watering. Water when the top inch of soil feels dry.", "Watering", 1 },
                    { 2, "Prune in late winter or early spring to remove dead or diseased wood and shape the plant.", "Pruning", 1 },
                    { 3, "Ensure the pot has drainage holes to prevent waterlogged soil.", "Container", 2 },
                    { 4, "Select a location with well-draining soil and adequate sunlight.", "Choose the Right Location", 3 },
                    { 5, "Ensure proper spacing between maple trees to allow for healthy growth.", "Spacing", 3 },
                    { 6, "They prefer warm temperatures. Protect them from cold drafts and frost, especially during winter.", "Temperature", 4 },
                    { 7, "They prefer well-draining soil. Amend heavy or compacted soil with organic matter to improve drainage.", "Soil", 5 },
                    { 8, "Use a balanced, all-purpose fertilizer when planting. Additional fertilization may not be necessary if the soil is nutrient-rich.", "Fertilization", 5 },
                    { 9, "Many bamboo varieties are spreading and can become invasive. Use barriers (rhizome barriers) to contain the spread of the roots.", "Barriers", 6 },
                    { 10, "Mulch around the base of the palm tree to conserve moisture, regulate soil temperature, and suppress weeds.", "Mulching", 7 },
                    { 11, "Ensure proper air circulation to minimize the risk of fungal diseases.", "Good Air Circulation", 8 },
                    { 12, "Orchids often require higher humidity levels. In drier climates, use humidity trays, humidifiers, or group plants together to create a more humid microenvironment.", "Humidity", 9 },
                    { 13, "Succulents can be propagated from leaf or stem cuttings. Allow cuttings to dry and callus before planting.", "Propagating", 10 },
                    { 14, "Put it around the base of lavender to conserve soil moisture and suppress weeds.", "Gravel", 11 },
                    { 15, "Plant tulip bulbs in the fall before the first frost. This allows them to establish roots before winter.", "Planting Time", 12 },
                    { 16, "Ferns thrive in indirect or filtered light. Avoid exposing them to direct sunlight, especially during the hot afternoon hours.", "Indirect Light", 13 },
                    { 17, "Wire branches carefully to shape and train your bonsai. Be mindful of the tree's natural growth pattern, and remove wires before they cut into the bark.", "Wiring", 14 },
                    { 18, "Allow Arctic Willow to maintain its natural, arching form. Minimal pruning is needed to enhance its graceful appearance. Embrace its natural growth habit for a more authentic look.", "Natural Shape", 15 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_GardenModelPlantModel_PlantsPlantId",
                table: "GardenModelPlantModel",
                column: "PlantsPlantId");

            migrationBuilder.CreateIndex(
                name: "IX_Gardens_user_id",
                table: "Gardens",
                column: "user_id",
                unique: true,
                filter: "[user_id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Instructions_plant_id",
                table: "Instructions",
                column: "plant_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GardenModelPlantModel");

            migrationBuilder.DropTable(
                name: "Instructions");

            migrationBuilder.DropTable(
                name: "Gardens");

            migrationBuilder.DropTable(
                name: "Plants");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
