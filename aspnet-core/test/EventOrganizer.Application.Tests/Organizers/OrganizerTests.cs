using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Identity;
using Xunit;
using Moq;

namespace EventOrganizer.Organizers
{
    public class OrganizerTests : EventOrganizerApplicationTestBase
    {
        private readonly IOrganizerAppService _organizerAppService;
        public OrganizerTests()
        {
            _organizerAppService = GetRequiredService<IOrganizerAppService>();
        }

        [Fact]
        public async Task Should_Get_All_Organizers()
        {
            //Act
            var organizerDtos = await _organizerAppService.GetListAsync(new GetOrganizerListDto());

            //Assert
            organizerDtos.TotalCount.ShouldBeGreaterThan(0);
            organizerDtos.Items.ShouldContain(u => u.Name == "Nabi");
        }

        [Fact]
        public async Task Should_Get_Organizer()
        {
            var organizerDto = await _organizerAppService.GetAsync(1);

            organizerDto.ShouldNotBeNull();
        }

        [Fact]
        public async Task Should_Create_Organizer()
        {
            var organizerDtos = _organizerAppService.CreateAsync(new CreateOrganizerDto()
            {
                Name="Rasul",
                BirthDate=new DateTime(2023,2,3),
                ShortBio="superkaa"
            });

            await organizerDtos.ShouldNotBeNull();
        }

        [Fact]
        public async Task Should_Update_Organizer()
        {
            var organizer = await _organizerAppService.GetAsync(1);

            var organizerDto = _organizerAppService.UpdateAsync(1, new UpdateOrganizerDto()
            {
                Name = "Rasul",
                BirthDate = new DateTime(2023, 2, 5),
                ShortBio = "suc"
            });

            Assert.NotEqual(organizerDto.ToString(), organizer.ToString());
        }

        [Fact]
        public void Should_Delete_Organizer()
        {
            var organizer = _organizerAppService.DeleteAsync(1);

            organizer.ShouldNotBeNull ();
        }
    }
}
