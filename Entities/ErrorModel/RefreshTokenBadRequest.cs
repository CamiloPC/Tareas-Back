﻿namespace TaskApi.Entities.ErrorModel
{
    public class RefreshTokenBadRequest : BadRequestException
    {
        public RefreshTokenBadRequest(): base("Invalid client request. The tokenDto has some invalid values.")
        {
        }
    }
}
