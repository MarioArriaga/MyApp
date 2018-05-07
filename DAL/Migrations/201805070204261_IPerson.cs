namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IPerson : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.People", newName: "IPersons");
            AddColumn("dbo.IPersons", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.IPersons", "Discriminator");
            RenameTable(name: "dbo.IPersons", newName: "People");
        }
    }
}
