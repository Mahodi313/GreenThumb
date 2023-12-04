using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GreenThumb.Migrations
{
    public partial class SeedInstructions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Instruction",
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Instruction",
                keyColumn: "instruction_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Instruction",
                keyColumn: "instruction_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Instruction",
                keyColumn: "instruction_id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Instruction",
                keyColumn: "instruction_id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Instruction",
                keyColumn: "instruction_id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Instruction",
                keyColumn: "instruction_id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Instruction",
                keyColumn: "instruction_id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Instruction",
                keyColumn: "instruction_id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Instruction",
                keyColumn: "instruction_id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Instruction",
                keyColumn: "instruction_id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Instruction",
                keyColumn: "instruction_id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Instruction",
                keyColumn: "instruction_id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Instruction",
                keyColumn: "instruction_id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Instruction",
                keyColumn: "instruction_id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Instruction",
                keyColumn: "instruction_id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Instruction",
                keyColumn: "instruction_id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Instruction",
                keyColumn: "instruction_id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Instruction",
                keyColumn: "instruction_id",
                keyValue: 18);
        }
    }
}
