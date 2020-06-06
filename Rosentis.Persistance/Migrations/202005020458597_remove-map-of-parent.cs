namespace Rosentis.Persistance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removemapofparent : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("shp.CartItems", "ParentId", "shp.CartItems");
            DropIndex("shp.CartItems", new[] { "ParentId" });
        }
        
        public override void Down()
        {
            CreateIndex("shp.CartItems", "ParentId");
            AddForeignKey("shp.CartItems", "ParentId", "shp.CartItems", "Id");
        }
    }
}
