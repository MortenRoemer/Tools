# MortenRoemer.Tools

This is just an experimentation-branch for rapid development of frameworks
and projects I'm working on.

As projects and artifacts outgrow their experimentation-stage they will be
moved to their own repositories.

As such this repository is perpetually work-in-progress and should not be
used in production-environments! But comments and feedback are always welcome.

Kind regards, Morten Römer

## MortenRoemer.Tools.Framework

As C#-development shifts more and more onto container- and cloud-native
contexts, it becomes exceedingly more difficult to develop and test these
applications, making the codebase more complex and dependencies hard to
understand.

This framework tries to give a cloud-native, easy-to-use application
framework, which builds upon state-of-the-art features in the C# language.

As such the leading architecture principles are including (but are not limited to):

* async should the default behavior
* dependencies are always injected and should be easy to substitute
* testing an application should be as straight-forward as developing it
* application developers should not worry about side-effects in the framework
as it should prevent side-effects through using pure-functions and holding state
in immutable data-classes
* interacting with the framework should be in a straight-forward fluent-api

### Planned Features

* Using and Substituting File Repositories (In Progress)
* Using and Substituting Tracing Services (In Progress)
* Using and Substituting Message Bus Services (Planned)
* Integrate seamlessly in serverless environments with functions (Planned)
