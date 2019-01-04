﻿using CorePub.Repositories.Articles.IProviders;
using CorePub.Repositories.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CorePub.Repositories.Articles.Commands
{
    public class ArticlesCommandHandler : IRequestHandler<CreateArticleCommand, CommandResult>
    {
        private IArticleService _articleService;

        public ArticlesCommandHandler(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public async Task<CommandResult> Handle(CreateArticleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var creationResult = await _articleService.CreateArticle(request.ArticleModel);
                return CommandResult.Success(creationResult);
            }         
            catch(AlreadyExistException ex)
            {

                return CommandResult.Error(new CreateCommentException(ex.Message, ex));
            }
            catch (Exception ex)
            {

                return CommandResult.Error(new CreateCommentException("There was an error in creating the article", ex));
            }
        }
    }
}
