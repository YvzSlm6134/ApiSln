<<<<<<< HEAD
﻿using ApiSln.Domain.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
=======
﻿using System;
>>>>>>> ece8842 (devam edilcek)
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSln.Persistence.Configurations
{
<<<<<<< HEAD
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            Category category1 = new()
            {
                Id = 1,
                Name = "Elektrik",
                Priorty = 1,
                ParentId = 0,
                İsDeleted = false,
                CreatedDate = DateTime.Now
            };
            Category category2 = new()
            {
                Id = 2,
                Name = "Moda",
                Priorty = 2,
                ParentId = 0,
                İsDeleted = false,
                CreatedDate = DateTime.Now
            };
            Category parent1 = new()
            {
                Id = 3,
                Name = "Bilgisayar",
                Priorty = 1,
                ParentId = 1,
                İsDeleted = false,
                CreatedDate = DateTime.Now
            };
            Category parent2 = new()
            {
                Id = 4,
                Name = "Kadın",
                Priorty = 1,
                ParentId = 1,
                İsDeleted = false,
                CreatedDate = DateTime.Now
            };
            builder.HasData(category1, category2, parent1, parent2);

        }
=======
    public class CategoryConfiguration : IEntityTypeConfiguration
    {
>>>>>>> ece8842 (devam edilcek)
    }
}
