exports = function(partition) {
  console.log(`User: ${context.user.id} trying to write partition ${partition}`);
    return partition === `${context.user.id}`;
};