import urlconfig from "@/config/urlconfig";
import StorageHelper from "@/helpers/StorageHelper";

async function getGroups() {
    return await fetch(`${urlconfig.protocol}://${urlconfig.base}${urlconfig.group}`,{
        method: "GET",
        headers: new Headers({
            'Authorization': 'Bearer ' + StorageHelper.get("login-token"),
            'Content-Type': 'application/json'
        })
    }).then(async response => {
        return {status: response.status,  body:await response.json()}})
}

async function getGroup(id) {
    return await fetch(`${urlconfig.protocol}://${urlconfig.base}${urlconfig.group}/${id}`,{
        method: "PUT",
        headers: new Headers({
            'Authorization': 'Bearer ' + StorageHelper.get("login-token"),
            'Content-Type': 'application/json'
        })
    }).then(async response => {return {status: response.status, body:await response.json()}})
}

/**
 *
 * @returns {Promise<number>} status
 * @param GroupName String
 * @param CourseID GUID
 * @param GroupID GUID
 */
async function putGroup(GroupName, CourseID, GroupID) {
    const response = await fetch(`${urlconfig.protocol}://${urlconfig.base}${urlconfig.group}/${GroupID}`,{
        method: "PUT",
        headers: new Headers({
            'Authorization': 'Bearer ' + StorageHelper.get("login-token"),
            'Content-Type': 'application/json'
        }),
        body: JSON.stringify({
            GroupID: GroupID,
            GroupName: GroupName,
            CourseID: CourseID
        })
    })
    return response.status;
}

/**
 *
 * @returns {Promise<number>}
 * @param GroupName
 * @param CourseID
 * @param GroupID
 */
async function postGroup(GroupName, CourseID, GroupID) {
    return await fetch(`${urlconfig.protocol}://${urlconfig.base}${urlconfig.group}`,{
        method: "POST",
        headers: new Headers({
            'Authorization': 'Bearer ' + StorageHelper.get("login-token"),
            'Content-Type': 'application/json'
        }),
        body: JSON.stringify({
            GroupID: GroupID,
            GroupName: GroupName,
            CourseID: CourseID
        })
    }).then(response => response.status)
}

/**
 *
 * @param id of the course to delete
 * @returns Status code
 */
async function deleteGroup(id) {
    return await fetch(`${urlconfig.base}${urlconfig.group}/${id}`,{
        method: 'DELETE',
        headers: new Headers({
            'Authorization': 'Bearer ' + StorageHelper.get("login-token"),
            'Content-Type': 'application/json'
        })
    }).then(response => response.status)
}

/**
 *
 * @param GroupName String
 * @param CourseID Guid
 * @param Users List of strings of exact usernames of users.
 * @returns {Promise<void>}
 */
async function postEntireGroup(GroupName, CourseID, Users){
    return await fetch(`${urlconfig.protocol}://${urlconfig.base}${urlconfig.group}`,{
        method: "POST",
        headers: new Headers({
            'Authorization': 'Bearer ' + StorageHelper.get("login-token"),
            'Content-Type': 'application/json'
        }),
        body: JSON.stringify({
            GroupName: GroupName,
            CourseID: CourseID,
            Users: Users
        })
    }).then(response => response.status)
}

async function getGroupMembers(GroupID){

    return await fetch(`${urlconfig.protocol}://${urlconfig.base}${urlconfig.groupAssignment}/${GroupID}`,{
        method: "GET",
        headers: new Headers({
            'Authorization': 'Bearer ' + StorageHelper.get("login-token"),
            'Content-Type': 'application/json'
        })
    }).then(async response => {return {status: response.status, body:await response.json()}})
}

async function addMemberToGroup(UserUsername, GroupID){
    return await fetch(`${urlconfig.protocol}://${urlconfig.base}${urlconfig.groupAssignment}/assign`,{
        method: "POST",
        headers: new Headers({
            'Authorization': 'Bearer ' + StorageHelper.get("login-token"),
            'Content-Type': 'application/json'
        }),
        body: JSON.stringify({
            UserUsername: UserUsername,
            GroupID: GroupID,
        })
    }).then(response => response.status)
}

async function removeMemberFromGroup(UserUsername, GroupID) {
    return await fetch(`${urlconfig.protocol}://${urlconfig.base}${urlconfig.groupAssignment}/unassign`,{
        method: "DELETE",
        headers: new Headers({
            'Authorization': 'Bearer ' + StorageHelper.get("login-token"),
            'Content-Type': 'application/json'
        }),
        body: JSON.stringify({
            UserUsername: UserUsername,
            GroupID: GroupID,
        })
    }).then(response => response.status)
}



export default {
    getGroups,
    getGroup,
    postGroup,
    putGroup,
    deleteGroup,
    postEntireGroup,
    getGroupMembers,
    removeMemberFromGroup,
    addMemberToGroup,
}