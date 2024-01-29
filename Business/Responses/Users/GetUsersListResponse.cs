using Business.Dtos.Users;

namespace Business.Responses.Users
{

    public class GetUsersListResponse
    {
        public ICollection<UsersListItemDto> Items { get; set; }

        public GetUsersListResponse()
        {
            Items = Array.Empty<UsersListItemDto>();
        }

        public GetUsersListResponse(ICollection<UsersListItemDto> items)
        {
            Items = items;
        }
    }
}