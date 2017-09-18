
// copied from solution to understand
// from: https://discuss.leetcode.com/topic/16406/accepted-c-solution-of-hashmap-in-4ms

// build HashMap first
typedef struct HashNode { // why is HashNode listed up here too??
    int key;
    int val
} HashNode;

typedef struct HashMap {
    int size;
    HashNode** storage; // ** = pointer to a pointer in declaration
} HashMap;              // ** = dereference of a dereference in a statement

// these are function signatures, not calls
HashMap* hash_create(int size); // need to create all hash methods
// no dot-notation for accessing
void hash_destroy(HashMap* hashMap); 
// always hash to pass hashmap to functions
void hash_set(HashMap* hashMap, int key, int value);
// returns a pointer to HashNode
HashNode* hash_get(HashMap* hashMap, int key);

// define function bodies
HashMap* hash_create(int size) {
  HashMap* hashMap = malloc(sizeof(HashMap));
  hashMap->size = size; // member variable assignment
  // calloc (clear-alloc): takes the space as 2 arguments, instead
  // of multiplying like in malloc (memory-allow). Also initializes
  // space to all zeros, malloc leaves the space uninitialized. Its
  // safer to zero out space if it isn't all going to be initialized
  // some other way
  hashMap->storage = calloc(size, sizeof(HashNode*));
  return hashMap;

}
void hash_destroy(Hashmap* hashMap) {
  for(int i=0; i < hashMap->size; i++) {
    HashNode* node;
    // if the map returns a node, free it (all other locations are
    // already free
    if((node = hashMap->storage[i])){
      free(node);
    }
  }
  // free the memory holding the pointer
  free(hashMap->storage);
  // free the memory pointing to the hashMap
  free(hashMap);
}//end hash_destory

void hash_set(HashMap* hashMap, int key, int value) {
  int hash = abs(key) % (hashMap->size); // simple hash
  HashNode* node;
  // uses the rolling mode of collision avoidance
  while((node = hashMap->storage[hash])) {
    if(hash < hashMap->size - 1) { // keep from out-of-bounds
    hash++; // change hash, but key stays the same
    } else {
      hash = 0; // roll around end
    }
  }
  // intialized immediately, can use malloc
  node = malloc(sizeof(HashNode));
  // add to map array
  node->key = key;
  node->val = value;
  hashMap->storage[hash] = node;      

}//end hash_set

/**
 * Note: The returned array must be malloced, assume caller calls free().
 */
int* twoSum(int* nums, int numsSize, int target) {
  HashMap* hashMap;
  HashNode* node;
  int rest, i;

  hashMap = hash_create(numsSize*2); //set load size to half
  for(i=0; i<numSize; i++) {
    rest = target - nums[i]; // rest is the target
    node = hash_get(hashMap, rest);
    // returned with a result
    if(node) {
      // can use malloc because initialized immediately
      int* result = malloc(sizeof(int) * 2);
      // returning indexes based on 1-index
      result[0] = node->val + 1; 
      result[1] = i + 1;
      hash_destroy(hashMap); // cleanup
      return result;      
    } else {
      hash_set(hashMap, nums[i], i);
    }
  }
  
}//end two_sum
