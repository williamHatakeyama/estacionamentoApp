﻿namespace estacionamentoApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbFinal2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clientes", "sexo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Clientes", "sexo");
        }
    }
}
