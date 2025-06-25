# SimpleBlogApp

There're 2 options to build

1. Docker
2. Mannual

# Docker (recommended)

Just use project's docker script <br />
How to use: https://docs.docker.com/reference/cli/docker/compose/up/

# Mannual

To build program create 2 SQL Databases Instances in: https://www.microsoft.com/en-us/download/details.aspx?id=42299 <br />
and config sql server with: 
https://aka.ms/ssmsfullsetup <br /> <br />

- (local)\UserDatabase <br />
- (local)\PostsDatabase <br />

<br />
CREATE 2 DATABASES: <br /><br />

- UserRepository <br />
- PostsRepository <br/ >
<br />
In PostsRepository create table named Posts with 4 columns:<br /><br />

- ID <br />
- username <br />
- postName <br />
- postData <br />
<br/>

create table OnlinePosts with previous columns <br />
create table Users with 3 columns: <br />
- ID <br />
- username <br />
- password <br /><br />

Notice you must change ID to primar key apply increment and must be int type<br /><br />

In UserDatabase create table named Users with 3 columns: <br />
- ID <br />
- username <br />
- Password <br /><br />

change ID with instructions above<br /><br />
