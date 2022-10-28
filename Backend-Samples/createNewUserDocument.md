exports = async function createNewUserDocument({user}) {
  const cluster = context.services.get("mongodb-atlas");
  const users = cluster.db("HouseMovingAssistantCluster").collection("User");
  return users.insertOne({
    _id: user.id,
    _partition: `${user.id}`,
    name: user.data.email
  });
};
