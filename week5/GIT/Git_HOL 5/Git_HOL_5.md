
# Git HOL 5: Cleanup and Push to Remote Git

## Objectives
- Explain how to clean up and push back to remote Git
- Execute steps involving cleanup and push to remote

## Prerequisites
- Git HOL 3 and Git HOL 4 completed
- Remote repository setup on GitHub/GitLab

## Step 1: Verify Master is Clean
git status

## Step 2: List All Available Branches
git branch -a

## Step 3: Pull Remote Repository to Master
git pull origin main

## Step 4: Push Pending Changes to Remote
git push origin main

## Step 5: Verify Changes in Remote Repository
## Open GitHub/GitLab and confirm:
## - All commits are visible
## - All files are present
## - Branch history is correct

## Step 6: Clean Up Local Branches
## Delete all merged branches
git branch -d GitNewBranch
git branch -d GitWork

## Step 7: Verify Clean State
git branch -a
git status
git log --oneline --graph --decorate

## Expected Output
## - master/main branch is clean
## - All changes pushed to remote
## - No pending local branches
## - Remote repository updated

## Complete Git Workflow Summary:
## 1. git init          — Initialize repository
## 2. git add .         — Stage all changes
## 3. git commit -m ""  — Commit with message
## 4. git branch        — Create branch
## 5. git checkout      — Switch branch
## 6. git merge         — Merge branches
## 7. git pull          — Get remote changes
## 8. git push          — Send local changes to remote
## 9. git log           — View commit history
## 10. git status       — Check working tree status

## Key Concepts
- git pull    — Fetches and merges remote changes
- git push    — Sends local commits to remote repo
- git branch -d — Deletes local branch safely
- git log     — Verifies all commits pushed
- Clean state — No uncommitted changes remaining