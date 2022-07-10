var UserName='kahkeshan';
var Password='kahkeshan';
function CreateTokken()
{
    var Tokken=UserName+':'+Password;
    var hash='Basic '+btoa(Tokken);
    return hash;
}