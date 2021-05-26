using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Aes.Api.Core.Controllers;
using Aes.Api.Core.Filters;
using Aes.Api.Core.Identity;
using Aes.Data.Esn.UserAccounts.Commands;
using Aes.Domain.Esn.UserAccounts;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Aes.Api.Esn.Users
{
    [Produces("application/json")]
    [Route("esn/users")]
    [AuthenticateJwt]
    [HttpException]
    [EnableCors("CorsPolicy")]
    public class UsersController : AesApiController
    {

        #region Route Constants

        public const string GET_ALL_USERS = "GetUsers";
        public const string GET_USERS_BY_ID = "GetUserById";
        public const string CREATE_USER = "CreateUser";
        public const string UPDATE_USER = "UpdateUser";
        public const string DELETE_USER = "DeleteUser";

        #endregion


        [HttpGet(Name=GET_ALL_USERS)]
        public IActionResult Get()
        {
            var service = new UserAccountService(CurrentUser.ToUser());
            var users = service.GetUserAccounts();
            var model = users.Select(user => UserModel.Map(user)).ToList();
            return Ok(model);
        }

        [HttpGet("{id:int}", Name = GET_USERS_BY_ID)]
        public IActionResult Get(int id)
        {
            var service = new UserAccountService(CurrentUser.ToUser());
            var user = service.GetUserAccount(id);
            return Ok(UserModel.Map(user));
        }

        [HttpPost(Name=CREATE_USER)]
        public IActionResult Post([FromBody]CreateUserModel createModel)
        {
            var service = new UserAccountService(CurrentUser.ToUser());
            var user = service.CreateUserAccount(CreateUserModel.Map(createModel));
            var model = UserModel.Map(user);
            return CreatedAtRoute(GET_USERS_BY_ID, new { id = model.Id }, model);
        }

        [HttpPut("{id:int}", Name = UPDATE_USER)]
        public IActionResult Put(int id, [FromBody]UpdateUserModel updateModel)
        {
            var service = new UserAccountService(CurrentUser.ToUser());
            var command = UpdateUserModel.Map(updateModel);
            command.UserAccountId = id;

            var user = service.UpdateUserAccount(command);
            return Ok(UserModel.Map(user));
        }
        [HttpDelete("{id:int}", Name = DELETE_USER)]
        public IActionResult Delete(int id)
        {
            var service = new UserAccountService(CurrentUser.ToUser());
            service.DeleteUserAccount(id);
            return NoContent();
        }
    }
}