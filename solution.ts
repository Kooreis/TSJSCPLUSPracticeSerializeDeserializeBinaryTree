class Codec {
    // Encodes a tree to a single string.
    serialize(root: TreeNode | null): string {
        if (root === null) {
            return 'X';
        }
        const leftSerialized = this.serialize(root.left);
        const rightSerialized = this.serialize(root.right);
        return root.val + ',' + leftSerialized + ',' + rightSerialized;
    }
}