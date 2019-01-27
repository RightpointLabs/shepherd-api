# Shepherd API

## Technology
This is an Azure Function project that serves as an API to an Azure Cosmos DB instance.

## Setup
- Install Node v10.13.x [https://nodejs.org](https://nodejs.org)
- Install .NET Core 2.2 SDK [https://www.microsoft.com/net/download](https://www.microsoft.com/net/download)
- Run `npm install -g azure-functions-core-tools`. _Note: if you have any issues installing this (e.g., you're on MacOS), check out the [official instructions](https://github.com/Azure/azure-functions-core-tools)_.

## Debugging
```
func host start --build --debug VSCode
```

## Entity Relationships
- ( person ) -[ request ]-> ( topic )
- ( person ) -[ commitment ]-> ( topic )
- ( person ) -[ vote ]-> ( topic )

## Backlog

### Topics
- `[GET] topics` - retrieve list of topics and related commitments
```
[
    {
        "id": "d033a5d1-5346-4133-baa9-3db379a8ea8b",
        "title": "Angular 6",
        "successCriteria": "Show me how to get to Hello World using the CLI",
        "requestor": "Jane Developer",
        "requestedDate": "11/03/2018 11:15 AM CT",
        "votes": 6,
        "commitments": [
            {
                "id": "c928a90b-1130-4315-a917-94f3971e9d6e",
                "teacher": "Joe Architect",
                "committedDate": "11/03/2018 11:24 AM CT",
                "eventDate": "11/09/2018 12:00 PM CT"
                "eventType": "Brain Food Friday"
            }
        ]
    },
    {
        "id": "35e837ae-d2fa-485d-a9ad-83f9e129b9e2",
        "title": "Sketch",
        "successCriteria": "I want to know how to publish design comps in Sketch. What are my options?",
        "requestor": "Jeff Designer",
        "requestedDate": "11/03/2018 11:26 AM CT",
        "votes": 3,
        "commitments": []
    }
]
```
- `[GET] topics/{id}` - retrieve a topics with related commitments
```
{
    "id": "d033a5d1-5346-4133-baa9-3db379a8ea8b",
    "title": "Angular 6",
    "successCriteria": "Show me how to get to Hello World using the CLI",
    "requestor": "Jane Developer",
    "requestedDate": "11/03/2018 11:15 AM CT",
    "votes": 6,
    "commitments": [
        {
            "id": "c928a90b-1130-4315-a917-94f3971e9d6e",
            "teacher": "Joe Architect",
            "committedDate": "11/03/2018 11:24 AM CT",
            "eventDate": "11/09/2018 12:00 PM CT"
            "eventType": "Brain Food Friday"
        }
    ]
}
```
- `[POST] topics` - create topic
```
{
    "title": "Angular 6",
    "successCriteria": "Show me how to get to Hello World using the CLI",
    "requestor": "Jane Designer"
}
```

### Commitments
- `[GET] commitments` - retrieve list of commitments with related topic
```
[
    {
        "id": "c928a90b-1130-4315-a917-94f3971e9d6e",
        "teacher": "Joe Architect",
        "committedDate": "11/03/2018 11:24 AM CT",
        "eventDate": "11/09/2018 12:00 PM CT"
        "eventType": "Brain Food Friday",
        "topic": {
            "id": "d033a5d1-5346-4133-baa9-3db379a8ea8b",
            "title": "Angular 6",
            "successCriteria": "Show me how to get to Hello World using the CLI",
            "requestor": "Jane Developer",
            "requestedDate": "11/03/2018 11:15 AM CT",
            "votes": 6
        }
    }
]
```
- `[GET] commitments/{id}` - retrieve a commitment by ID with related topic
```
{
    "id": "c928a90b-1130-4315-a917-94f3971e9d6e",
    "teacher": "Joe Architect",
    "committedDate": "11/03/2018 11:24 AM CT",
    "eventDate": "11/09/2018 12:00 PM CT"
    "eventType": "Brain Food Friday",
    "topic": {
        "id": "d033a5d1-5346-4133-baa9-3db379a8ea8b",
        "title": "Angular 6",
        "successCriteria": "Show me how to get to Hello World using the CLI",
        "requestor": "Jane Developer",
        "requestedDate": "11/03/2018 11:15 AM CT",
        "votes": 6
    }
}
```
- `[POST] commitments` - create commitment to teach a topic
```
{
    "topicId": "d033a5d1-5346-4133-baa9-3db379a8ea8b",
    "teacher": "Joe Architect",
    "eventDate": "11/09/2018 12:00 PM CT"
    "eventType": "Brain Food Friday"
}
```