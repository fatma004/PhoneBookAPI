using AutoMapper;
using PhoneBook.Application.Features.Contact.Command.CreateContact;
using PhoneBook.Application.Features.Contact.Command.DeleteContact;
using PhoneBook.Application.Features.Contact.Command.UpdateContact;
using PhoneBook.Application.Features.Contact.Query.GetContactDetails;
using PhoneBook.Application.Features.Contact.Query.GetContactsList;
using PhoneBook.Application.Features.UserAccount.Command.CreateUserAccount;
using PhoneBook.Domain;
using PhoneBook.API.EndPoints.UserEndPoints;
using PhoneBook.Application.Features.UserAccount.Query.Login;
using PhoneBook.API.EndPoints.ContactEndPoints;

namespace PhoneBook.Application.Profiles
{
    public class AutoMapperProfile :Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreateUserAccountRequest, CreateUserAccountInput>().ReverseMap();
            CreateMap<CreateUserAccountResponse, CreateUserAccountOutput>().ReverseMap();

            CreateMap<LoginRequest, LoginInput>().ReverseMap();
            CreateMap<LoginResponse, LoginOutput>().ReverseMap();

            CreateMap<CreateContactRequest, CreateContactInput>().ReverseMap();
            CreateMap<UpdateContactRequest, UpdateContactInput>().ReverseMap();
            CreateMap<DeleteContactRequest, DeleteContactInput>().ReverseMap();
            CreateMap<Contact, UpdateContactInput>().ReverseMap();

            CreateMap<GetContactDetailsOutput, GetContactDetailsResponse>().ReverseMap();
            CreateMap<GetContactDetailsInput, GetContactDetailsRequest>().ReverseMap();

            CreateMap<GetUserContactsOutput, GetUserContactsResponse>().ReverseMap();
            CreateMap<GetUserContactsInput, GetUserContactsResponse>().ReverseMap();
            CreateMap<GetContactDetailsOutput, Contact>().ReverseMap();




            CreateMap<Contact, GetUserContactsOutput>().ReverseMap();
            CreateMap<Contact, GetContactDetailsOutput>().ReverseMap();
            CreateMap<Contact, CreateContactInput>().ReverseMap();
            CreateMap<Contact, UpdateContactRequest>().ReverseMap();
            CreateMap<Contact, DeleteContactInput>().ReverseMap();

            CreateMap<SeUser, CreateUserAccountInput>().ReverseMap();

        }
    }
}
