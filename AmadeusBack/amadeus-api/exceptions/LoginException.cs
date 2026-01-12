using System;

namespace amadeus_api.exceptions;

public class LoginException(string message) : Exception(message)
{

}
