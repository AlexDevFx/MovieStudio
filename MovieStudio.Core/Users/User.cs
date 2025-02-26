﻿using MovieStudio.Contacts;
using MovieStudio.Contacts.Users;
using MovieStudio.Core.Movies;

namespace MovieStudio.Core.Users;

public class User: IHasUpdateTime
{
    public User(string firstName, string secondName, string userName, HashSet<UserRoleType> roles)
    {
        FirstName = firstName;
        SecondName = secondName;
        UserName = userName;
        _roles = roles;
    }
    
    public User(string firstName, string secondName, string userName, Director director)
    {
        FirstName = firstName;
        SecondName = secondName;
        UserName = userName;
        DirectorId = director.Id;
        Director = director;
        _roles = new HashSet<UserRoleType> { UserRoleType.Director };
    }
    
    public User(string firstName, string secondName, string userName, Actor actor)
    {
        FirstName = firstName;
        SecondName = secondName;
        UserName = userName;
        ActorId = actor.Id;
        Actor = actor;
        _roles = new HashSet<UserRoleType> { UserRoleType.Actor };
    }

    public int Id { get; set; }
    public string FirstName { get; set; }
    public string SecondName { get; set; }
    public string UserName { get; private set; }
    
    public string PasswordHash { get; private set; }
    
    public int? DirectorId { get; set; }
    public Director? Director { get; private set; }
    
    public int? ActorId { get; set; }
    public Actor? Actor { get; private set; }

    private readonly HashSet<UserRoleType> _roles;
    public bool HasPermission(UserPermissionType permission)
    {
        foreach (var role in _roles)
        {
            if (UsersRoles.RolesPermissions.TryGetValue(role, out var permissions)
                && permissions.Contains(permission))
            {
                return true;
            }
        }

        return false;
    }

    public bool HasRole(UserRoleType role) => _roles.Contains(role);
    public DateTime? Updated { get; set; }
}