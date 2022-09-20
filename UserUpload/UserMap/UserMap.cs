using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Identity;
using System;
using System.Globalization;
using UserUpload.DTO;
using UserUpload.Entities;

namespace UserUpload.UserMap
{
    public static class UserMap 
    {
        public static User ToEntity(this UserDTO map)
        {
            var user = new User();
            user.Name = map.PersonName;
            user.Age = map.Age;
            user.Pets = new List<Pet>();

            if (map.Pet_1 != null)
                user.Pets.Add(new Pet()
                {
                    Name = map.Pet_1,
                    Type = map.Pet_1_Type
                });
            else if (map.Pet_2 != null)
                user.Pets.Add(new Pet()
                {
                    Name = map.Pet_2,
                    Type = map.Pet_2_Type
                });
            else if (map.Pet_3 != null)
                user.Pets.Add(new Pet()
                {
                    Name = map.Pet_3,
                    Type = map.Pet_3_Type
                });

            return user;
        }

        public static Userpload ToExport(this User user)
        {
            var upload = new Userpload();
            upload.Age = user.Age;
            upload.Name = user.Name;
            if (user.Pets.Count > 0)
                upload.Pets = user.Pets.Select(p => p.ToExport()).ToList();
            return upload;
        }

        public static PetUpload ToExport(this Pet pet)
        {
            var upload = new PetUpload();
            upload.Name = pet.Name;
            upload.Type = pet.Type;
            return upload;
        }


    }
}
