# Kinetic
This application should help developer teams organize their work by implementing **Agile** and **Waterfall** approaches. The idea is inspired by: [ClickUp](https://app.clickup.com/), [Jira](https://www.atlassian.com/software/jira).

![logo](https://i.ibb.co/4S0sGQ9/Kinetic-logo.png)

## Entities
### User
User should login to access it's spaces. One user can have or consist in multiple spaces. Also, user can add other users to friend list.

Actions:
1. Login(by email and password or external services as Google, Github, Outlook)
2. Manage spaces
3. Add users to friend list

### Space
Space is an environment which is dedicated for developing some project or service.

Actions:
- Add users by email or id
- Create **Task**s
- Create **Role**s
- Attach role to user
- View backlog of space

#### Role
Space has Role entity for configuring restrictions for users. Users with role *Admin* can create custom roles with choosen list of restrictions.

#### Task
Space has Task entity which can be assigned to user.

Task's attributes:
- Tag(for sorting, filtering, etc.)
- State(free, In progress, completed, on review, finished)
- User which task is assigned to
- Users' comments
- Subtasks

---
