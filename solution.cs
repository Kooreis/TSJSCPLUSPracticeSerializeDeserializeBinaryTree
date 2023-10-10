Here is a JavaScript solution using depth-first search for both serialization and deserialization:

```javascript
function TreeNode(val, left, right) {
    this.val = (val===undefined ? 0 : val)
    this.left = (left===undefined ? null : left)
    this.right = (right===undefined ? null : right)
}

var serialize = function(root) {
    if(root == null) {
        return 'X,';
    }
    let leftSerialized = serialize(root.left);
    let rightSerialized = serialize(root.right);
    return root.val + ',' + leftSerialized + rightSerialized;
};

var deserialize = function(data) {
    let nodesQueue = data.split(',');
    return helper(nodesQueue);
};

function helper(nodesQueue) {
    let valueForNode = nodesQueue.shift();
    if(valueForNode == 'X') {
        return null;
    }
    let newNode = new TreeNode(parseInt(valueForNode));
    newNode.left = helper(nodesQueue);
    newNode.right = helper(nodesQueue);
    return newNode;
}

// Test the solution
let root = new TreeNode(1);
root.left = new TreeNode(2);
root.right = new TreeNode(3);
root.right.left = new TreeNode(4);
root.right.right = new TreeNode(5);

let serializedData = serialize(root);
console.log(serializedData);

let deserializedData = deserialize(serializedData);
console.log(deserialize(serializedData));
```

This solution uses a pre-order traversal (node, left, right) to serialize the binary tree. During deserialization, it uses the same pre-order traversal to reconstruct the tree. The 'X' character is used to denote null nodes in the serialized string.