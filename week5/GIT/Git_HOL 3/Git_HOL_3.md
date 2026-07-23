# Git HOL 3: Branching and Merging

## Objectives
- Explain branching and merging
- Create a branch request in GitLab
- Create a merge request in GitLab

## Step 1: Create a New Branch
git branch GitNewBranch

## Step 2: List All Branches
git branch -a

## Step 3: Switch to New Branch
git checkout GitNewBranch

## Step 4: Add Files to New Branch
echo "This is a new feature" > feature.txt
git add feature.txt
git commit -m "Added feature.txt in GitNewBranch"

## Step 5: Check Status
git status

## Step 6: Switch Back to Master
git checkout master

## Step 7: List Differences Between Master and Branch
git diff master GitNewBranch

## Step 8: Merge Branch to Master
git merge GitNewBranch

## Step 9: Observe Log After Merging
git log --oneline --graph --decorate

## Step 10: Delete Branch After Merging
git branch -d GitNewBranch

## Step 11: Verify Branch Deleted
git branch -a

## Expected Output
- GitNewBranch created and switched successfully
- feature.txt added and committed in branch
- Branch merged to master successfully
- Branch deleted after merging
- Log shows merge commit

## Key Concepts
- git branch        — Creates a new branch
- git checkout      — Switches between branches
- git merge         — Merges branch into current branch
- git branch -d     — Deletes a branch after merging
- git log --graph   — Visual representation of commits
- git diff          — Shows differences between branches