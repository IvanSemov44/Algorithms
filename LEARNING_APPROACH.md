# Learning Approach for Algorithm Patterns

## Overview
This document outlines the **correct way** to learn algorithm patterns. The goal is **understanding + active problem-solving**, not passive code reading.

## Three-Stage Learning Process

### Stage 1: Pattern Explanation
**Goal:** Understand the concept, not memorize code.

**What you should get:**
- Definition of the pattern (What is it?)
- When to use it (When does it apply?)
- Why it works (The intuition)
- Real-world analogy (Optional but helpful)

**Example for Stack Pattern:**
```
What: A data structure that follows LIFO (Last In, First Out)
When: When you need to process items in reverse order, or match pairs
Why: Because the most recent item is always available instantly
Analogy: Like a stack of plates—you take from the top
```

**What you should NOT get:**
- ❌ Complete working code
- ❌ Implementations
- ❌ Solutions to problems

---

### Stage 2: Simple Examples (No Code Yet)
**Goal:** Trace through the logic manually to build intuition.

**What you should get:**
- 2-3 simple examples traced **step-by-step**
- Visual diagrams or ASCII art showing state changes
- Edge cases explained

**Example for Stack Pattern:**
```
Problem: Check if parentheses are balanced in "()"

Step 1: See '(' → Push to stack
        Stack: ['(']

Step 2: See ')' → Does top match? Yes!
        Pop from stack
        Stack: []

Result: Stack is empty → Valid!
```

**What you should NOT get:**
- ❌ Code implementation
- ❌ LeetCode solutions
- ❌ Ready-to-run examples

---

### Stage 3: Skeleton Code + Tests
**Goal:** Implement the pattern yourself, validate with tests.

**What you should get:**
- Empty function signature with detailed comments
- Test cases that cover edge cases
- Instructions on what to implement

**Example:**
```csharp
public bool IsValid(string s)
{
    // TODO: Implement using Stack pattern
    // 1. Create a stack
    // 2. Loop through each character
    // 3. If opening bracket → push
    // 4. If closing bracket → pop and check if it matches
    // 5. Return true if stack is empty at end
    return false; // placeholder
}
```

**What you should NOT get:**
- ❌ Working implementation
- ❌ The actual solution
- ❌ Hints that spoil the logic

**Tests provided should:**
- ✅ Show expected inputs/outputs
- ✅ Cover all edge cases
- ✅ Validate your implementation when you run them

---

## Instructions for AI Assistant

When you ask to learn a new pattern, provide these instructions:

> "Follow the THREE-STAGE approach:
> 
> **Stage 1:** Explain the pattern (what, when, why)
> 
> **Stage 2:** Show 2-3 worked examples with manual tracing
> 
> **Stage 3:** Give me skeleton code + tests to implement myself
> 
> Do NOT solve the problems for me. I need to write the code."

---

## Pattern Learning Checklist

Before moving to the next pattern, ensure:

- ✅ I understand **what** the pattern is
- ✅ I understand **when** to use it
- ✅ I can trace through a simple example manually
- ✅ I've implemented at least 2-3 problems myself
- ✅ All tests pass for my implementations
- ✅ I can explain it to someone else

---

## Patterns to Learn (In Order)

1. **Stack** — LIFO operations, matching pairs, backtracking
2. **Queue** — FIFO operations, breadth-first traversal
3. **Two Pointers** — Efficient iteration on sorted arrays
4. **Sliding Window** — Efficient substring/subarray operations
5. **HashMap/HashSet** — Fast lookups and uniqueness tracking
6. **Linked List** — Sequential data with pointers
7. **Binary Search** — Logarithmic search on sorted data
8. **Dynamic Programming** — Optimal substructure problems
9. **Graph Traversal** — DFS and BFS on graphs
10. **Heap** — Priority-based operations

---

## What Success Looks Like

✅ You can implement a problem using the pattern without looking at solutions  
✅ Your code passes all test cases  
✅ You understand **why** your solution works  
✅ You can identify when to use this pattern in future problems  

❌ Copying working code  
❌ Not understanding what you wrote  
❌ Only passing tests by trial-and-error  
