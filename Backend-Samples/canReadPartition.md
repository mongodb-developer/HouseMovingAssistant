exports = function(partition) {
  console.log(`User: ${context.user.id} trying to read partition ${partition}`);
  return partition === `${context.user.id}`;
};