﻿using wca.compras.domain.Dtos;
using wca.compras.domain.Entities;
using wca.compras.domain.Interfaces;
using wca.compras.domain.Interfaces.Repositories;
using wca.compras.domain.Interfaces.Services;
using wca.compras.domain.Util;
using static wca.compras.domain.Dtos.ProfileDtos;

namespace wca.compras.services
{
    public class ProfileService : IProfileService
    {
        private readonly IProfileRepository _profileRepo;
        private readonly IRepository<ProfileHasPermission> _profilePermissionsRepo;

        public ProfileService(IProfileRepository profileRepository, IRepository<ProfileHasPermission> profilePermissionRepository)
        {
            _profileRepo = profileRepository;
            _profilePermissionsRepo = profilePermissionRepository;
        }
        public async Task<ProfileDto> Create(ProfileDtos.CreateProfileDto profile)
        {

            var data = new Profile()
            {
                Name = profile.Name,
                Description = profile.Description,
                Active = true
            };

            await _profileRepo.CreateAsync(data);

            foreach(var permission in profile.Permissions)
            {
                await _profilePermissionsRepo.CreateAsync(new ProfileHasPermission()
                {
                    ProfileId = data.Id,
                    PermissionId = permission.Id,
                });
            }
            
            return data.asDto();
        }

        public Task<Pagination<ProfileDto>> GetPagination(string termo, int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public async Task<ProfilePermissionsDto> GetProfilePermissions(string id)
        {

            var profile = await _profileRepo.GetWithPermissionsById(id);

            return profile.asDto();
        }

        public Task<ProfileDto> Update(UpdateProfileDto profile)
        {
            throw new NotImplementedException();
        }
    }
}
