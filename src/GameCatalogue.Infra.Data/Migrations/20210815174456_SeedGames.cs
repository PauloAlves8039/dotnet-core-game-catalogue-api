using Microsoft.EntityFrameworkCore.Migrations;

namespace GameCatalogue.Infra.Data.Migrations
{
    public partial class SeedGames : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("INSERT INTO Games(Name,Producer,Gender,Quantity,Image,PlatformId) " +
            "VALUES('Resident Evil 7','Capcom Ltd','Action, Fear',1,'resident-evil-7.png',1)");

            mb.Sql("INSERT INTO Games(Name,Producer,Gender,Quantity,Image,PlatformId) " +
            "VALUES('Hellblade: Senua s Sacrifice','Ninja Theory','Action, Epic',1,'hellblade.png',2)");

            mb.Sql("INSERT INTO Games(Name,Producer,Gender,Quantity,Image,PlatformId) " +
            "VALUES('God Of War','Santa Monica Studio','Action, Epic',1,'god-of-war.png',3)");
        }

        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("DELETE FROM Games");
        }
    }
}
