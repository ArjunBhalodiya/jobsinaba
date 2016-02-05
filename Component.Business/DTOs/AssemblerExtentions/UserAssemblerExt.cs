using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Linq;
using JobsInABA.DTOs;
using JobsInABA.DAL.Entities;

namespace JobsInABA.DTOs.Assemblers
{
    public static partial class UserAssembler
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="UserDTO"/> converted from <see cref="User"/>.</param>
        static partial void OnDTO(this User entity, UserDTO dto) {

            if (entity.UserAddresses != null && entity.UserAddresses.Count > 0)
            {
                dto.UserAddresses = UserAddressAssembler.ToDTOs(entity.UserAddresses);
            }

            if (entity.UserEmails != null && entity.UserEmails.Count > 0)
            {
                dto.UserEmails = UserEmailAssembler.ToDTOs(entity.UserEmails);
            }

            if (entity.UserPhones != null && entity.UserPhones.Count > 0)
            {
                dto.UserPhones = UserPhoneAssembler.ToDTOs(entity.UserPhones);
            }
        }

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="User"/> converted from <see cref="UserDTO"/>.</param>
        static partial void OnEntity(this UserDTO dto, User entity) { 
        
        }
    }
}
