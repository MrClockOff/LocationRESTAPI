# LocationRESTAPI
REST API for logging and retrieving user's location

Endpoints:

- for posting location for specific user: POST api/location/users/{userId}
- for getting current location for specific user: GET api/location/users/{userId}/current 
- for getting location history for specific user: GET api/location/users/{userId}/history 
- for getting current location for all users: GET api/location/users/current
