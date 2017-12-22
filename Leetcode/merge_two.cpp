
/**
 * Definition for singly-linked list.
 * struct ListNode {
 *     int val;
 *     ListNode *next;
 *     ListNode(int x) : val(x), next(NULL) {}
 * };
 */
class Solution {
public:
  ListNode* mergeTwoLists(ListNode* l1, ListNode* l2) {

    // get which pointer to hold onto as first
    if(l1 == NULL) return l2;
    if(l2 == NULL) return l1;
    if(l1 == NULL && l2 == NULL) return NULL;


    // can't use l1 as the base node, overwrite the passed info
    ListNode dummy(INT_MIN);
    ListNode* out = &dummy;

    int v1, v2;
    while(l1 != NULL && l2 != NULL) {

      v1 = l1->val;
      v2 = l2->val;

      if(v1 < v2) {
	out->next = l1;
	l1 = l1->next;
      } else {
	out->next = l2;
	l2 = l2->next;
      }
      out = out->next;
    }

    if(l1 == NULL) {
      out->next = l2;
      return dummy.next;
    } else {
      out->next = l1;
      return dummy.next;
    }
  }
};
