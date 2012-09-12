using FubuTestingSupport;
using HtmlTags.Conventions;
using NUnit.Framework;
using Rhino.Mocks;

namespace HtmlTags.Testing.Conventions
{
    [TestFixture]
    public class TagGeneratorFactoryTester : InteractionContext<TagGeneratorFactory>
    {
        private ITagRequestActivator[] theActivators;
        private FakeSubject theSubject;
        private HtmlTag theTag;
        private HtmlConventionLibrary theLibrary;

        protected override void beforeEach()
        {
            theActivators = Services.CreateMockArrayFor<ITagRequestActivator>(5);

            theActivators[0].Stub(x => x.Matches(typeof(FakeSubject))).Return(true);
            theActivators[1].Stub(x => x.Matches(typeof(FakeSubject))).Return(false);
            theActivators[2].Stub(x => x.Matches(typeof(FakeSubject))).Return(true);
            theActivators[3].Stub(x => x.Matches(typeof(FakeSubject))).Return(false);
            theActivators[4].Stub(x => x.Matches(typeof(FakeSubject))).Return(true);

            theSubject = new FakeSubject
            {
                Name = "Jeremy",
                Level = 10
            };

            theTag = new HtmlTag("div");

            theLibrary = new HtmlConventionLibrary();

            Services.Inject(theLibrary);
        }

        [Test]
        public void sets_the_active_profile_to_the_child_generators()
        {
            ClassUnderTest.ActiveProfile = "Blue";

            ClassUnderTest.GeneratorFor<FakeSubject>().ActiveProfile.ShouldEqual("Blue");
            ClassUnderTest.GeneratorFor<SecondSubject>().ActiveProfile.ShouldEqual("Blue");
        }
    }
}