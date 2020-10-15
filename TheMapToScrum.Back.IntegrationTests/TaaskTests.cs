using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using TheMapToScrum.Back.API;
using TheMapToScrum.Back.Common.Enums;
using TheMapToScrum.Back.DTO;
using Xunit;

namespace TheMapToScrum.Back.IntegrationTests
{
    public class TaaskTests : IClassFixture<TestFixture<Startup>>
    {
        private HttpClient Client;

        public TaaskTests(TestFixture<Startup> fixture)
        {
            Client = fixture.Client;
        }

        [Fact]
        public async Task TestGetOk()
        {
            // Arrange
            var request = "/api/taask";

            // Act
            var response = await Client.GetAsync(request);

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task TestGetAsyncByIdOk()
        {
            // Arrange
            var request = "/api/taask/1";

            // Act
            var response = await Client.GetAsync(request);

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task TestGetAsyncByIdShouldReturnNotFoundError()
        {
            // Arrange
            var request = "/api/taask/99999";

            // Act
            var response = await Client.GetAsync(request);

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        

        [Fact]
        public async Task TestCreateOk()
        {
            // Arrange
            var request = new
            {
                Url = "/api/taask",
                Body = new
                {
                    
                    Label = "US Status",
                    Number = 1,
                    Feature = "Display Different Status for US",
                    Assumption = "some assumption",
                    AcceptanceCriteria = "DOD",
                    Risk = "moderate",
                    TaskStatus = (int)eTaskStatus.Done,
                    ProjectId = 6,
                    UserStoryId = 15,
                    DeveloperId = 6,
                    Priority = 1
                    
                }
            };

            // Act
            var response = await Client.PostAsync(request.Url, ContentHelper.GetStringContent(request.Body));
            var jsonFromPostResponse = await response.Content.ReadAsStringAsync();
            var singleResponse = JsonConvert.DeserializeObject<TaaskDTO>(jsonFromPostResponse);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.True(singleResponse.Id.HasValue);
        }

        [Fact]
        public async Task TestUpdateOk()
        {
            // Arrange
            var request = new
            {
                Url = "/api/taask",
                Body = new
                {
                    Id = 1,
                    Label = "US Status update",
                    Number = 1,
                    Feature = "Display Different Status for US update",
                    Assumption = "some assumption update",
                    AcceptanceCriteria = "DOD",
                    Risk = "moderate",
                    TaskStatus = (int)eTaskStatus.Done,
                    ProjectId = 6,
                    UserStoryId = 15,
                    DeveloperId = 6,
                    Priority = 1

                }
            };

            // Act
            var response = await Client.PutAsync(request.Url, ContentHelper.GetStringContent(request.Body));
            var jsonFromPostResponse = await response.Content.ReadAsStringAsync();
            var singleResponse = JsonConvert.DeserializeObject<TaaskDTO>(jsonFromPostResponse);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.True(singleResponse.Id == 1);
            Assert.True(((DateTime)(singleResponse.DateModification)).Day == DateTime.Now.Day && ((DateTime)(singleResponse.DateModification)).Month == DateTime.Now.Month);
        }

        [Fact]
        public async Task TestDeleteOk()
        {
            // Arrange
            var request = "api/taask/1";

            // Act
            var response = await Client.DeleteAsync(request);
            var getResponse = await Client.GetAsync(request);
            var jsonFromPostResponse = await getResponse.Content.ReadAsStringAsync();
            var singleResponse = JsonConvert.DeserializeObject<TaaskDTO>(jsonFromPostResponse);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.True(singleResponse.IsDeleted);
        }
    }
}
