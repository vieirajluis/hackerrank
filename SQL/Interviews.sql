--Interviews
--Write a query to print the contest_id, hacker_id, name, and the sums of total_submissions, total_accepted_submissions, --total_views, and total_unique_views for each contest sorted by contest_id. Exclude the contest from the result if all four --sums are 0.

--Contests (contest_id, hacker_id,name)
--Colleges (college_id, contest_id)
--Challenges (challenge_id, college_id)
--View_Stats (challenge_id, total_views, total_unique_views)
--Submission_Stats (challenge_id,total_submissions, total_accepted_submissions)

Select distinct ct.contest_id , ct.hacker_id ,ct.name
,sum(SS.TOTALSUBMISSIONS) as TOTALSUBMISSIONS
,sum(SS.TOTALACCEPTEDSUBMISSIONS) as TOTALACCEPTEDSUBMISSIONS
,sum(VS.TOTALVIEWS) as TOTALVIEWS
,sum(VS.TOTALUNIQUEVIEWS) as TOTALUNIQUEVIEWS

from Contests as ct join Colleges as cl on cl.contest_id=ct.contest_id
				 join Challenges as ch on ch.college_id=cl.college_id
                 left join (select challenge_id, sum(total_views) as TOTALVIEWS
                       , sum(total_unique_views) as TOTALUNIQUEVIEWS
                       from View_Stats  group by challenge_id) as VS 
                       on VS.challenge_id = ch.challenge_id
               	 left join (select challenge_id, sum(total_submissions) as TOTALSUBMISSIONS
                       ,sum(total_accepted_submissions) as TOTALACCEPTEDSUBMISSIONS
                       from Submission_Stats  group by challenge_id) as SS 
                       on SS.challenge_id = ch.challenge_id

group by ct.contest_id, ct.hacker_id,ct.name
having (sum(SS.TOTALSUBMISSIONS) + sum(SS.TOTALACCEPTEDSUBMISSIONS) + sum(VS.TOTALVIEWS) + sum(VS.TOTALUNIQUEVIEWS))>0
order by ct.contest_id;

