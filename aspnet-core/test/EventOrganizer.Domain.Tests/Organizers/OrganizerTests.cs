using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using NSubstitute;

namespace EventOrganizer.Organizers
{
    public class OrganizerTests
    {
        private readonly IOrganizerRepository _fakeRepo;
        private readonly OrganizerManager _organizerManager;
        private readonly Organizer _organizer;

        public OrganizerTests()
        {
            _fakeRepo = Substitute.For<IOrganizerRepository>();
            _organizerManager = new OrganizerManager(_fakeRepo);
            _organizer = new Organizer();
        }

        [Fact]
        public void Organizer_ShouldSuccessfull()
        {
            //Assert
            _organizer.Name.ShouldBeNull();
        }

        [Theory]
        [InlineData("Rasul")]
        public void Should_Change_Name(string name)
        {
            _organizer.ChangeName(name);

            _organizer.Name.ShouldNotBeNull();
        }
    }
}
